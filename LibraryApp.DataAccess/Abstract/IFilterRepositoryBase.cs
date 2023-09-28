using System.Linq.Expressions;
using LibraryApp.DataAccess.Common.Abstract;
using LibraryApp.Entities.Domain;

namespace LibraryApp.DataAccess.Abstract;

public interface IFilterRepositoryBase<TEntity,TResponse> 
    where TResponse:class,IResponseDtoSignature,new()
    where TEntity:BaseEntity,new()
{
    Task<TResponse> GetEntityAsync(Expression<Func<TEntity, bool>> filter);
    Task<List<TResponse>> GetEntitiesAsync(Expression<Func<TEntity, bool>> filter = null);
}