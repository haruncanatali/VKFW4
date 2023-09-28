using LibraryApp.DataAccess.Abstract;
using LibraryApp.DataAccess.Common.Abstract;
using LibraryApp.DataAccess.Common.Concrete;
using LibraryApp.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DataAccess.Concrete;

public class EntityRepositoryBase<TEntity> : IEntityRepositoryBase<TEntity> where TEntity:BaseEntity,new()
{
    private readonly ApplicationContext _context;

    public EntityRepositoryBase(ApplicationContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Added;
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        var entityControl = await FindAsync(entity.Id);

        if (entityControl != null)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Kayıt bulunamadı.");
        }
    }

    public async Task DeleteByIdAsync(long id)
    {
        var entity = await FindAsync(id);

        if (entity != null)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Kayıt bulunamadı.");
        }
    }

    public async Task<TEntity?>? FindAsync(long id)
    {
        TEntity? entity = await _context.Set<TEntity>().FindAsync(id);
        return entity;
    }
}