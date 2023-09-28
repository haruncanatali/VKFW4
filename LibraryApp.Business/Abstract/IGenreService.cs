using LibraryApp.DataAccess.Common.Dtos.GenreDtos;
using LibraryApp.Entities.Domain;

namespace LibraryApp.Business.Abstract;

public interface IGenreService : IServiceCollection<Genre,GenreResponseModel>
{
    
}