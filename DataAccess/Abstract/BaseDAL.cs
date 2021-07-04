using Core.DataAccess.Abstract;
using Core.Entity.Abstract;
using Core.Entity.Enum;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccess.Abstract
{
    public class BaseDAL<T> : IBaseDAL<T> where T:class,IBaseEntity
    {
        private readonly WofranDbContext _context;
        protected DbSet<T> _table;
        public BaseDAL(WofranDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<bool> Activate(Guid id)
        {
            T activated = await GetByID(id);
            activated.Status = Status.Active;
            return await Update(activated);
        }

        public async Task<bool> Add(T entity)
        {
            await _table.AddAsync(entity);
            return await Save() > 0;
        }

        public async Task<bool> Add(List<T> entities)
        {
            await _table.AddRangeAsync(entities);
            return await Save() > 0;
        }

        public async Task<bool> Any(Expression<Func<T, bool>> expression) => await _table.AnyAsync(expression);

        public async Task<bool> Delete(T entity)
        {
            _table.Remove(entity);
            return await Save() > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            T deletedEntity = await _table.FindAsync(id);
            return await Delete(deletedEntity);
        }

        public async Task<bool> DeleteAll(Expression<Func<T, bool>> expression)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var collection = await GetAll(expression);
                    int count = 0;

                    foreach (var item in collection)
                    {
                        bool opResult =await Delete(item);
                        if (opResult) count++;
                    }

                    if (collection.Count == count) ts.Complete();
                    else return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression) => await _table.Where(expression).FirstOrDefaultAsync();

        public async Task<List<T>> GetActive()
        {
            return await _table.Where(x => x.Status == Status.Active).ToListAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? await _table.ToListAsync() : await _table.Where(expression).ToListAsync();
        }

        public async Task<T> GetByID(Guid id) => await _table.FindAsync(id);

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(T entity)
        {
            _table.Update(entity);
            return await Save() > 0;
        }
    }
}
