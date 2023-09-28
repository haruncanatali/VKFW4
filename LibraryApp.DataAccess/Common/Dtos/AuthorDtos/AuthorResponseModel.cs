using AutoMapper;
using LibraryApp.DataAccess.Common.Abstract;
using LibraryApp.DataAccess.Common.Dtos.BookDtos;
using LibraryApp.DataAccess.Common.Mappings;
using LibraryApp.Entities.Domain;

namespace LibraryApp.DataAccess.Common.Dtos.AuthorDtos;

public class AuthorResponseModel : IMapFrom<Author>, IResponseDtoSignature
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthdate { get; set; }
    public List<BookResponseModel> Books { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Author, AuthorResponseModel>()
            .ForMember(dest => dest.Books, opt =>
                opt.MapFrom(c => c.Books));
    }
}