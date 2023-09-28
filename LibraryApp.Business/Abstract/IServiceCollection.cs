using System.Linq.Expressions;
using LibraryApp.DataAccess.Common.Abstract;
using LibraryApp.Entities.Domain;

namespace LibraryApp.Business.Abstract;

public interface IServiceCollection<TEntity,TResponse>
    where TEntity:BaseEntity,new()
    where TResponse:class,IResponseDtoSignature,new()
{
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteByIdAsync(long id);
    Task<TEntity?>? FindAsync(long id);
    Task<TResponse> GetEntityAsync(Expression<Func<TEntity, bool>> filter);
    Task<List<TResponse>> GetEntitiesAsync(Expression<Func<TEntity, bool>> filter = null);
}