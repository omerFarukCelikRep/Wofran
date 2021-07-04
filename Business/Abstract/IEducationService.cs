using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEducationService
    {
        Task<bool> Add(Education entity);
        Task<bool> Add(List<Education> entities);
        Task<bool> Delete(Education entity);
        Task<bool> Delete(Guid id);
        Task<bool> DeleteAll(Expression<Func<Education, bool>> expression);
        Task<bool> Update(Education entity);
        Task<Education> Get(Expression<Func<Education, bool>> expression);
        Task<Education> GetByID(Guid id);
        Task<List<Education>> GetAll(Expression<Func<Education, bool>> expression = null);
        Task<bool> Any(Expression<Func<Education, bool>> expression);
    }
}
