class Resolvers {
    public String GetFormattedDate([Parent]Book e){
        return e.PublishDate.ToShortDateString();
    }
}
