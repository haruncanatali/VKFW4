using LibraryApp.DataAccess.Common.Dtos.BookDtos;
using LibraryApp.Entities.Domain;

namespace LibraryApp.Business.Abstract;

public interface IBookService : IServiceCollection<Book,BookResponseModel>
{
    
}