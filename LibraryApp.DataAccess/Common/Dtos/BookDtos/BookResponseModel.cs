using System.Net.NetworkInformation;
using AutoMapper;
using LibraryApp.DataAccess.Common.Abstract;
using LibraryApp.DataAccess.Common.Mappings;
using LibraryApp.Entities.Domain;

namespace LibraryApp.DataAccess.Common.Dtos.BookDtos;

public class BookResponseModel : IMapFrom<Book>, IResponseDtoSignature
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string ISBN { get; set; }
    public int PageCount { get; set; }
    public bool BookStatus { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Book, BookResponseModel>()
            .ForMember(dest => dest.BookStatus, opt =>
                opt.MapFrom(c => c.BookStatus == Entities.Enums.BookStatus.Active));
    }
}