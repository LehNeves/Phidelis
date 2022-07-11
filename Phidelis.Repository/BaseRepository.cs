using Phidelis.Entities.Interfaces;
using Phidelis.Repository.Context;
using Phidelis.Repository.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Phidelis.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : class, IBaseModel
    {
        protected readonly PhidelisEFContext _context;

        protected BaseRepository(PhidelisEFContext context)
        {
            _context = context;
        }

        public void Add(T obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            T oldObj = FindById(id);

            _context.Remove(oldObj);
        }

        public T FindById(int id)
        {
            return _context.Find<T>(id);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return GetAll().Where(filter);
        }

        public IQueryable<T> GetAll<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> orderBy)
        {
            return GetAll(filter).OrderBy(orderBy);
        }

        public IQueryable<T> GetAll<TKey>(Expression<Func<T, TKey>> orderBy)
        {
            return GetAll().OrderBy(orderBy);
        }

        public void Update(int id, T obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
        }
    }
}
