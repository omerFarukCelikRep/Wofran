using Business.Abstract;
using Core.DataAccess.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class JobSeekerManager : IJobSeekerService
    {
        private IJobSeekerDAL _jobSeekerDAL;

        public JobSeekerManager(IJobSeekerDAL jobSeekerDAL)
        {
            _jobSeekerDAL = jobSeekerDAL;
        }

        public async Task<bool> Activate(Guid id)
        {
            return await _jobSeekerDAL.Activate(id);
        }

        public async Task<bool> Add(JobSeeker entity)
        {
            return await _jobSeekerDAL.Add(entity);
        }

        public async Task<bool> Add(List<JobSeeker> entities)
        {
            return await _jobSeekerDAL.Add(entities);
        }

        public async Task<bool> Any(Expression<Func<JobSeeker, bool>> expression)
        {
            return await _jobSeekerDAL.Any(expression);
        }

        public async Task<bool> Delete(JobSeeker entity)
        {
            return await _jobSeekerDAL.Delete(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _jobSeekerDAL.Delete(id);
        }

        public async Task<bool> DeleteAll(Expression<Func<JobSeeker, bool>> expression)
        {
            return await _jobSeekerDAL.DeleteAll(expression);
        }

        public async Task<JobSeeker> Get(Expression<Func<JobSeeker, bool>> expression)
        {
            return await _jobSeekerDAL.Get(expression);
        }

        public async Task<List<JobSeeker>> GetActive()
        {
            return await _jobSeekerDAL.GetActive();
        }

        public async Task<List<JobSeeker>> GetAll(Expression<Func<JobSeeker, bool>> expression = null)
        {
            return await _jobSeekerDAL.GetAll(expression);
        }

        public async Task<JobSeeker> GetByID(Guid id)
        {
            return await _jobSeekerDAL.GetByID(id);
        }

        public async Task<bool> Update(JobSeeker entity)
        {
            return await _jobSeekerDAL.Update(entity);
        }
    }
}
