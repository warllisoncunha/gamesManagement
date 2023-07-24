using gamesManagement.Infrastructure.Context;
using gamesManagement.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace gamesManagement.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly SqlServerContext _dbContext;
        private readonly DbSet<T> _entitiySet;

        public BaseRepository(SqlServerContext dbContext)
        {
            _dbContext = dbContext;
            _entitiySet = _dbContext.Set<T>();
        }

        private async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        private void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Add(T entity)
        {
            _dbContext.Add(entity);
            SaveChanges();
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.AddAsync(entity, cancellationToken);
            await SaveChangesAsync();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbContext.AddRange(entities);
            SaveChanges();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await _dbContext.AddRangeAsync(entities, cancellationToken);
            await SaveChangesAsync();
        }

        public T Get(Expression<Func<T, bool>> expression)
            => _entitiySet.FirstOrDefault(expression);

        public T Get(int id) => _entitiySet.Find(id);

        public IEnumerable<T> GetAll()
            => _entitiySet.AsEnumerable();

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
            => _entitiySet.Where(expression).AsEnumerable();

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _entitiySet.ToListAsync(cancellationToken);

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
            => await _entitiySet.Where(expression).ToListAsync(cancellationToken);

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
            => await _entitiySet.FirstOrDefaultAsync(expression, cancellationToken);

        public void Remove(T entity)
        {
            _dbContext.Remove(entity);
            SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.RemoveRange(entities);
            SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
            SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Update(entity);
            await SaveChangesAsync();
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbContext.UpdateRange(entities);
            SaveChanges();
        }
    }
}
