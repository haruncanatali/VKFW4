using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryApp.DataAccess.Abstract;
using LibraryApp.DataAccess.Common.Concrete;
using LibraryApp.DataAccess.Common.Dtos.BookDtos;
using LibraryApp.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DataAccess.Concrete;

public class BookDal : EntityRepositoryBase<Book>,IBookDal
{
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;
    public BookDal(ApplicationContext context, IMapper mapper) : base(context)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<BookResponseModel> GetEntityAsync(Expression<Func<Book, bool>> filter)
    {
        return await _context.Books.Where(filter).ProjectTo<BookResponseModel>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }

    public async Task<List<BookResponseModel>> GetEntitiesAsync(Expression<Func<Book, bool>> filter = null)
    {
        return filter != null
            ? await _context.Books
                .Where(filter)
                .ProjectTo<BookResponseModel>(_mapper.ConfigurationProvider)
                .ToListAsync()
            : await _context.Books
                .ProjectTo<BookResponseModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
    }
}