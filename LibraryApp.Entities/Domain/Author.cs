namespace LibraryApp.Entities.Domain;

public class Author : BaseEntity
{
    public Author()
    {
        Books = new List<Book>();
    }
    
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthdate { get; set; }

    public List<Book> Books { get; set; }
}