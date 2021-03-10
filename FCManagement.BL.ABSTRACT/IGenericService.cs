using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FCManagement.BL.ABSTRACT
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        //Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate);

        Task CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UpdateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<int> CountAllAsync();
    }
}
