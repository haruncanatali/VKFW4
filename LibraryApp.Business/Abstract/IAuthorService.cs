using LibraryApp.DataAccess.Common.Dtos.AuthorDtos;
using LibraryApp.Entities.Domain;

namespace LibraryApp.Business.Abstract;

public interface IAuthorService : IServiceCollection<Author,AuthorResponseModel>
{
    Task DeleteAuthorWithBooks(long id);
}