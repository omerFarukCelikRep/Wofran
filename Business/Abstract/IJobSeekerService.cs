using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IJobSeekerService
    {
        Task<bool> Add(JobSeeker entity);
        Task<bool> Add(List<JobSeeker> entities);
        Task<bool> Delete(JobSeeker entity);
        Task<bool> Delete(Guid id);
        Task<bool> DeleteAll(Expression<Func<JobSeeker, bool>> expression);
        Task<bool> Update(JobSeeker entity);
        Task<JobSeeker> Get(Expression<Func<JobSeeker, bool>> expression);
        Task<JobSeeker> GetByID(Guid id);
        Task<List<JobSeeker>> GetAll(Expression<Func<JobSeeker, bool>> expression = null);
        Task<List<JobSeeker>> GetActive();
        Task<bool> Activate(Guid id);
        Task<bool> Any(Expression<Func<JobSeeker, bool>> expression);
    }
}
