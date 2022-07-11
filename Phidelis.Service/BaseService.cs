using Phidelis.Entities.Interfaces;
using Phidelis.Repository.Interfaces;
using Phidelis.Service.Interfaces;
using System.Collections.Generic;
using System;

namespace Phidelis.Service
{
    public abstract class BaseService<D, T> : IBaseService<D, T>
        where T : IBaseModel
        where D : IBaseDTO<T>
    {
        protected readonly IBaseRepository<T> _repo;

        protected BaseService(IBaseRepository<T> repo)
        {
            _repo = repo;
        }

        public void Add(D obj)
        {
            _repo.Add(obj.ConvertToModel());
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public T FindById(int id)
        {
            return _repo.FindById(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repo.GetAll();
        }

        public void Update(int id, D obj)
        {
            if (id == 0)
            {
                throw new ArgumentException("Parameter invalid", "Id");
            }

            _repo.Update(id, obj.ConvertToModel());
        }
    }
}
