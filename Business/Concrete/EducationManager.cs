using Business.Abstract;
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
    public class EducationManager : IEducationService
    {
        private readonly IEducationDAL _educationDAL;

        public EducationManager(IEducationDAL educationDAL)
        {
            _educationDAL = educationDAL;
        }

        public async Task<bool> Add(Education entity)
        {
            return await _educationDAL.Add(entity);
        }

        public async Task<bool> Add(List<Education> entities)
        {
            return await _educationDAL.Add(entities);
        }

        public async Task<bool> Any(Expression<Func<Education, bool>> expression)
        {
            return await _educationDAL.Any(expression);
        }

        public async Task<bool> Delete(Education entity)
        {
            return await _educationDAL.Delete(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _educationDAL.Delete(id);
        }

        public async Task<bool> DeleteAll(Expression<Func<Education, bool>> expression)
        {
            return await _educationDAL.DeleteAll(expression);
        }

        public async Task<Education> Get(Expression<Func<Education, bool>> expression)
        {
            return await _educationDAL.Get(expression);
        }

        public async Task<List<Education>> GetAll(Expression<Func<Education, bool>> expression = null)
        {
            return await _educationDAL.GetAll(expression);
        }

        public async Task<Education> GetByID(Guid id)
        {
            return await _educationDAL.GetByID(id);
        }

        public async Task<bool> Update(Education entity)
        {
            return await _educationDAL.Update(entity);
        }
    }
}
