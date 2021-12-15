using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NultienShop.IDataAccess
{
    public interface IBaseRepository
    {
        Task<T> GetByFilter<T>(Expression<Func<T, bool>> filter) where T : class;

        Task<List<T>> GetListByFilter<T>(Expression<Func<T, bool>> filter) where T : class;

        Task<int> SaveContextWithTransaction();

        IExecutionStrategy GetExecutionStrategy();

        Task<int> SaveContextAsync();

        void AddOrUpdateContext<T>(T entity) where T : class;

        void AddOrUpdateContext<T>(List<T> entities) where T : class;

        Task<bool> Any<T>(Expression<Func<T, bool>> filter) where T : class;
    }
}