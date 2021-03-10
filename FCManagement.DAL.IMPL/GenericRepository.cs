using FCManagement.DAL.ABSTRACT;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FCManagement.DAL.IMPL
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected FitnessDbContext _dbContext;
        private DbSet<TEntity> dbEntity;

        public GenericRepository(FitnessDbContext dbContext)
        {
            _dbContext = dbContext;
            dbEntity = _dbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbEntity.ToListAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await dbEntity.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var answer = await dbEntity.FindAsync(id);

            if (answer == null)
                return false;

            dbEntity.Remove(answer);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            var answer = _dbContext.Entry(entity).State;
            if (answer != EntityState.Modified)
                return false;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await dbEntity.FindAsync(id);
        }

        public async Task<int> CountAllAsync()
        {
            return await dbEntity.CountAsync();
        }

        public async Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbEntity.Where(predicate).ToListAsync();
        }

        //public void Add(TEntity obj)//Insert
        //{
        //    dbEntity.Add(obj);
        //}

        //public void Delete(object manufactureId)
        //{
        //    TEntity model = dbEntity.Find(manufactureId);
        //    dbEntity.Remove(model);
        //    _dbContext.SaveChanges();
        //}

        //public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<TEntity> GetAll()
        //{
        //    return dbEntity.ToList();
        //}

        //public TEntity GetById(object manufactureId)//different find
        //{
        //    return dbEntity.Find(manufactureId);
        //}

        //public void Save()
        //{
        //    _dbContext.SaveChanges();
        //}

        //public void Update(TEntity obj)
        //{
        //    _dbContext.Entry(obj).State = EntityState.Modified;
        //    _dbContext.SaveChanges();
        //}
    }
}
