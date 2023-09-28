namespace LibraryApp.Entities.Domain;

public class Genre : BaseEntity
{
    public Genre()
    {
        Books = new List<Book>();
    }
    
    public string Name { get; set; }

    public List<Book> Books { get; set; }
}