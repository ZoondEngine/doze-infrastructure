using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Doze.Nt.Server.Database
{
    public abstract class BaseAccessor<T> : IDatabaseAccessor where T : class
    {
        protected DbSet<T> CurrentWorkSet { get; set; }
        protected DatabaseContext CurrentContext { get; set; }
        protected int AccessCount { get; set; } = 0;
        protected int QueriesCount { get; set; } = 0;

        public BaseAccessor(DbSet<T> workset, DatabaseContext context)
        {
            CurrentWorkSet = workset;
            CurrentContext = context;
        }

        public List<T> SelectAll()
        {
            QueriesCount++;
            return CurrentWorkSet.ToList();
        }
        public async Task<List<T>> SelectAllAsync()
        {
            QueriesCount++;
            return await CurrentWorkSet.ToListAsync();
        }

        public T SelectOne(Expression<Func<T, bool>> predicate)
        {
            QueriesCount++;
            return CurrentWorkSet.FirstOrDefault(predicate);
        }
        public async Task<T> SelectOneAsync(Expression<Func<T, bool>> predicate)
        {
            QueriesCount++;
            return await CurrentWorkSet.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            QueriesCount++;
            return CurrentWorkSet.Where(predicate);
        }
        public async Task<IQueryable<T>> WhereAsync(Expression<Func<T, bool>> predicate)
        {
            QueriesCount++;
            return await Task.Run(() => CurrentWorkSet.Where(predicate));
        }

        public ImmutableList<T> SelectAsImmutable()
        {
            QueriesCount++;
            return CurrentWorkSet.ToList().ToImmutableList();
        }
        public async Task<ImmutableList<T>> SelectAsImmutableAsync()
        {
            QueriesCount++;
            return await Task.Run(() => CurrentWorkSet.ToList().ToImmutableList());
        }

        public void UpdateAll(Action<T> everyItemCallback)
        {
            QueriesCount++;
            CurrentWorkSet.ForEachAsync(everyItemCallback);
        }
        public async Task UpdateAllAsync(Action<T> everyItemCallback)
        {
            QueriesCount++;
            await CurrentWorkSet.ForEachAsync(everyItemCallback);
        }

        public int Save()
        {
            QueriesCount++;
            return CurrentContext.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            QueriesCount++;
            return await CurrentContext.SaveChangesAsync();
        }

        public virtual DbSet<T> Access()
        {
            AccessCount++;
            return CurrentWorkSet;
        }

        public string GetModelName()
            => typeof(T).Name;

        public int GetAccessCount()
            => AccessCount;

        public int GetQueriesCount()
            => QueriesCount;
    }
}
