using Phidelis.Entities.Interfaces;
using System.Collections.Generic;

namespace Phidelis.Service.Interfaces
{
    public interface IBaseService<D, T>
        where T : IBaseModel
        where D : IBaseDTO<T>
    {
        T FindById(int id);
        IEnumerable<T> GetAll();
        void Add(D obj);
        void Delete(int id);
        void Update(int id, D obj);
    }
}
