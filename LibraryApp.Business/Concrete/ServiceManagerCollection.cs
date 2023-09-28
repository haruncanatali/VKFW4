using System.Linq.Expressions;
using FluentValidation;
using LibraryApp.Business.Abstract;
using LibraryApp.Business.Tools;
using LibraryApp.DataAccess.Abstract;
using LibraryApp.DataAccess.Common.Abstract;
using LibraryApp.Entities.Domain;

namespace LibraryApp.Business.Concrete;

public class ServiceManagerCollection<TEntity,TResponse,TDal,TValidator> : IServiceCollection<TEntity,TResponse>
    where TEntity:BaseEntity,new()
    where TResponse:class,IResponseDtoSignature,new()
    where TDal:IEntityRepositoryBase<TEntity>,IFilterRepositoryBase<TEntity,TResponse>
    where TValidator:IValidator
{
    private readonly TDal _dal;
    private readonly TValidator _validator;

    public ServiceManagerCollection(TDal dal, TValidator validator)
    {
        _dal = dal;
        _validator = validator;
    }

    public async Task AddAsync(TEntity entity)
    {
        ValidationTool.Validate(_validator,entity);
        await _dal.AddAsync(entity);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        ValidationTool.Validate(_validator,entity);
        await _dal.UpdateAsync(entity);    
    }

    public async Task DeleteByIdAsync(long id)
    {
        await _dal.DeleteByIdAsync(id);
    }

    public async Task<TEntity?>? FindAsync(long id)
    {
        return await _dal.FindAsync(id);
    }

    public async Task<TResponse> GetEntityAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _dal.GetEntityAsync(filter);
    }

    public async Task<List<TResponse>> GetEntitiesAsync(Expression<Func<TEntity, bool>> filter = null)
    {
        return await _dal.GetEntitiesAsync(filter);
    }
}