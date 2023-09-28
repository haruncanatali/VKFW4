namespace LibraryApp.Api.Models;

public class UpdateAuthorRequestModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthdate { get; set; }
}