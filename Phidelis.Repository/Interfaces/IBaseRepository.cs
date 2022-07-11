using Phidelis.Entities.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Phidelis.Repository.Interfaces
{
    public interface IBaseRepository<T>
        where T : IBaseModel
    {
        T FindById(int id);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter);
        IQueryable<T> GetAll<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> orderBy);
        IQueryable<T> GetAll<TKey>(Expression<Func<T, TKey>> orderBy);
        void Add(T obj);
        void Delete(int id);
        void Update(int id, T obj);
    }
}
