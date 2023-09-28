using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryApp.DataAccess.Abstract;
using LibraryApp.DataAccess.Common.Concrete;
using LibraryApp.DataAccess.Common.Dtos.AuthorDtos;
using LibraryApp.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DataAccess.Concrete;

public class AuthorDal : EntityRepositoryBase<Author>, IAuthorDal
{
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;
    
    public AuthorDal(ApplicationContext context, IMapper mapper) : base(context)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AuthorResponseModel> GetEntityAsync(Expression<Func<Author, bool>> filter)
    {
        return await _context.Authors
                .Where(filter)
                .ProjectTo<AuthorResponseModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
    }

    public async Task<List<AuthorResponseModel>> GetEntitiesAsync(Expression<Func<Author, bool>> filter = null)
    {
        return filter != null
            ? await _context.Authors
                .Where(filter)
                .Include(c=>c.Books)
                .ProjectTo<AuthorResponseModel>(_mapper.ConfigurationProvider)
                .ToListAsync()
            : await _context.Authors
                .Include(c=>c.Books)
                .ProjectTo<AuthorResponseModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
    }

    public async Task DeleteAuthorWithBooks(long id)
    {
        Author? author = await base.FindAsync(id);

        if (author != null)
        {
            List<Book> books = await _context.Books.Where(c => c.AuthorId == id).ToListAsync();

            if (books is { Count: > 0 })
            {
                _context.Books.RemoveRange(books);
                await _context.SaveChangesAsync();
            }

            await base.DeleteByIdAsync(id);
        }
    }
}