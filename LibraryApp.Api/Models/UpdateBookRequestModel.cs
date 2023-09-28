using LibraryApp.Entities.Enums;

namespace LibraryApp.Api.Models;

public class UpdateBookRequestModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string ISBN { get; set; }
    public int PageCount { get; set; }
    public BookStatus BookStatus { get; set; }
    public long GenreId { get; set; }
    public long AuthorId { get; set; }
}