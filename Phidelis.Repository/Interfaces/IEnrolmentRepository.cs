using Phidelis.Entities.Models;
using System.Linq;

namespace Phidelis.Repository.Interfaces
{
    public interface IEnrolmentRepository: IBaseRepository<Enrolment>
    {
        public IQueryable<Enrolment> FindByName(string nome);
    }
}
