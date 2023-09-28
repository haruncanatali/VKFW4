using LibraryApp.Business.Abstract;
using LibraryApp.Business.Validations;
using LibraryApp.DataAccess.Abstract;
using LibraryApp.DataAccess.Common.Dtos.BookDtos;
using LibraryApp.Entities.Domain;

namespace LibraryApp.Business.Concrete;

public class BookManager : ServiceManagerCollection<Book,BookResponseModel,IBookDal,BookValidator>,IBookService
{
    public BookManager(IBookDal dal, BookValidator validator) : base(dal, validator)
    {
    }
}