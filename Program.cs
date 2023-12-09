var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication();

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<BookType>();

var app = builder.Build();

app.UseStaticFiles();
app.UseAuthentication();

app.MapGet("/", () => "Hello World!");

app.MapGraphQL();

app.Run();
