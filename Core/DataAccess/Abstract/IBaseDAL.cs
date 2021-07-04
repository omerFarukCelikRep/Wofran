using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface IBaseDAL<T> where T:class,IBaseEntity
    {
        Task<bool> Add(T entity);
        Task<bool> Add(List<T> entities);
        Task<bool> Delete(T entity);
        Task<bool> Delete(Guid id);
        Task<bool> DeleteAll(Expression<Func<T, bool>> expression);
        Task<bool> Update(T entity);
        Task<T> Get(Expression<Func<T, bool>> expression);
        Task<T> GetByID(Guid id);
        Task<List<T>> GetAll(Expression<Func<T, bool>> expression = null);
        Task<List<T>> GetActive();
        Task<bool> Activate(Guid id);
        Task<bool> Any(Expression<Func<T, bool>> expression);
        Task<int> Save();
    }
}
