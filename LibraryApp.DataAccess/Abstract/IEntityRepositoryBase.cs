using LibraryApp.Entities.Domain;

namespace LibraryApp.DataAccess.Abstract;

public interface IEntityRepositoryBase<TEntity> where TEntity: BaseEntity,new()
{
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteByIdAsync(long id);
    Task<TEntity?>? FindAsync(long id);
}