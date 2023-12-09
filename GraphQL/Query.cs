using System.Text.Json;
using System.Text.Json.Serialization;

public class Query {
    public List<Book> Books(string nameContains = "")
    {
        string fileName = "Database/books.json";
        string jsonString = File.ReadAllText(fileName);
        var books =  JsonSerializer.Deserialize<List<Book>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } })!;
        throw new Exception("Error retrieving data");
        return books.Where(b => b.Name.IndexOf(nameContains) >=0).ToList();
    }
}

public class BookType : ObjectType<Book> {
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor.Field("publishDate").ResolveWith<Resolvers>(r => r.GetFormattedDate(default!));
    }
}