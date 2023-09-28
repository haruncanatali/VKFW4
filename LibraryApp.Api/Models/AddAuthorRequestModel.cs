namespace LibraryApp.Api.Models;

public class AddAuthorRequestModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthdate { get; set; }
}