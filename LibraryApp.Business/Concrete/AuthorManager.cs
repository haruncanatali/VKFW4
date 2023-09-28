using LibraryApp.Business.Abstract;
using LibraryApp.Business.Validations;
using LibraryApp.DataAccess.Abstract;
using LibraryApp.DataAccess.Common.Dtos.AuthorDtos;
using LibraryApp.Entities.Domain;

namespace LibraryApp.Business.Concrete;

public class AuthorManager : ServiceManagerCollection<Author,AuthorResponseModel,IAuthorDal,AuthorValidator>,IAuthorService
{
    private readonly IAuthorDal _dal;
    public AuthorManager(IAuthorDal dal, AuthorValidator validator) : base(dal, validator)
    {
        _dal = dal;
    }

    public async Task DeleteAuthorWithBooks(long id)
    {
        await _dal.DeleteAuthorWithBooks(id);
    }
}