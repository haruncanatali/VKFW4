using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryApp.DataAccess.Abstract;
using LibraryApp.DataAccess.Common.Concrete;
using LibraryApp.DataAccess.Common.Dtos.GenreDtos;
using LibraryApp.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DataAccess.Concrete;

public class GenreDal : EntityRepositoryBase<Genre>, IGenreDal
{
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;
    
    public GenreDal(ApplicationContext context, IMapper mapper) : base(context)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GenreResponseModel> GetEntityAsync(Expression<Func<Genre, bool>> filter)
    {
        return await _context.Genres
               .Where(filter)
               .Include(c => c.Books)
               .ProjectTo<GenreResponseModel>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync();
    }

    public async Task<List<GenreResponseModel>> GetEntitiesAsync(Expression<Func<Genre, bool>> filter = null)
    {
        return filter != null
            ? await _context.Genres
                .Where(filter)
                .Include(c => c.Books)
                .ProjectTo<GenreResponseModel>(_mapper.ConfigurationProvider)
                .ToListAsync()
            : await _context.Genres
                .Include(c => c.Books)
                .ProjectTo<GenreResponseModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

    }
}