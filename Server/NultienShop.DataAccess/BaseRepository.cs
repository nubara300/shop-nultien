using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NultienShop.DataAccess.Domain;
using NultienShop.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NultienShop.DataAccess
{
    public class BaseRepository : IBaseRepository
    {
        protected readonly AppDBContext _context;

        public BaseRepository(AppDBContext context)
        {
            _context = context;
        }

        public IExecutionStrategy GetExecutionStrategy() => _context.Database.CreateExecutionStrategy();

        public async Task<IDbContextTransaction> GetTransaction() => await _context.Database.BeginTransactionAsync();

        public async Task<T> GetByFilter<T>(Expression<Func<T, bool>> filter) where T : class
        {
            return await _context.Set<T>().Where(filter).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetListByFilter<T>(Expression<Func<T, bool>> filter) where T : class
        {
            return await _context.Set<T>().Where(filter).AsNoTracking().ToListAsync();
        }

        public void AddOrUpdateContext<T>(T entity) where T : class
        {
            bool conversionSuccess = long.TryParse(entity.GetType().GetProperty(entity.GetType().Name + "Id").GetValue(entity, null).ToString(), out long id);
            bool isUpdate = conversionSuccess && id > 0;
            _ = isUpdate ? _context.Set<T>().Update(entity) : _context.Set<T>().Add(entity);
        }

        public void AddOrUpdateContext<T>(List<T> entities) where T : class
        {
            if (entities != null && entities.Count > 0)
            {
                string baseEntName = entities.First().GetType().Name;
                foreach (var entitet in entities)
                {
                    bool conversionSuccess = long.TryParse(entitet.GetType().GetProperty(baseEntName + "Id").GetValue(entitet, null).ToString(), out long id);
                    bool isUpdate = conversionSuccess && id > 0;
                    _ = isUpdate ? _context.Set<T>().Update(entitet) : _context.Set<T>().Add(entitet);
                }
            }
        }

        public async Task<int> SaveContextAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> Any<T>(Expression<Func<T, bool>> filter) where T : class
        {
            return await _context.Set<T>().Where(filter).AsNoTracking().AnyAsync();
        }

        public async Task<int> Count<T>(Expression<Func<T, bool>> filter) where T : class
        {
            return await _context.Set<T>().Where(filter).AsNoTracking().CountAsync();
        }

        //public async Task<int> Count<T>() where T : class
        //{
        //    return await _context.Set<T>().AsNoTracking().CountAsync();
        //}
    }
}