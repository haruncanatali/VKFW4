using LibraryApp.DataAccess.Common.Dtos.AuthorDtos;
using LibraryApp.Entities.Domain;

namespace LibraryApp.DataAccess.Abstract;

public interface IAuthorDal : IEntityRepositoryBase<Author>, IFilterRepositoryBase<Author,AuthorResponseModel>
{
    Task DeleteAuthorWithBooks(long id);
}