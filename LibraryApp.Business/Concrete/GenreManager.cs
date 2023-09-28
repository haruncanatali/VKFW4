using LibraryApp.Business.Abstract;
using LibraryApp.Business.Validations;
using LibraryApp.DataAccess.Abstract;
using LibraryApp.DataAccess.Common.Dtos.GenreDtos;
using LibraryApp.Entities.Domain;

namespace LibraryApp.Business.Concrete;

public class GenreManager : ServiceManagerCollection<Genre,GenreResponseModel,IGenreDal,GenreValidator>, IGenreService
{
    public GenreManager(IGenreDal dal, GenreValidator validator) : base(dal, validator)
    {
    }
}