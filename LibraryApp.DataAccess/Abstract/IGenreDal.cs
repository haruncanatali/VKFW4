using LibraryApp.DataAccess.Common.Dtos.GenreDtos;
using LibraryApp.Entities.Domain;

namespace LibraryApp.DataAccess.Abstract;

public interface IGenreDal : IEntityRepositoryBase<Genre>, IFilterRepositoryBase<Genre,GenreResponseModel>
{
    
}