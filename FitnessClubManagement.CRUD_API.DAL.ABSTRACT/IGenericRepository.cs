using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FitnessClubManagement.CRUD_API.DAL.ABSTRACT
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);//??
        TEntity GetById(object objectId);

        void Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(object objectId);
        void Save();

    }
}
