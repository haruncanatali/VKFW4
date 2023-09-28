using LibraryApp.Entities.Enums;

namespace LibraryApp.Entities.Domain;

public class Book : BaseEntity
{
    public string Name { get; set; }
    public string ISBN { get; set; }
    public int PageCount { get; set; }
    public BookStatus BookStatus { get; set; }

    public long GenreId { get; set; }
    public long AuthorId { get; set; }
    
    public Genre Genre { get; set; }
    public Author Author { get; set; }
}