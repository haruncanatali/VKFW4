using LibraryApp.DataAccess.Common.Dtos.BookDtos;
using LibraryApp.Entities.Domain;

namespace LibraryApp.DataAccess.Abstract;

public interface IBookDal : IEntityRepositoryBase<Book>, IFilterRepositoryBase<Book,BookResponseModel>
{
    
}