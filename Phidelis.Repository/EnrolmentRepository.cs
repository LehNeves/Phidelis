using Phidelis.Entities.Models;
using Phidelis.Repository.Context;
using Phidelis.Repository.Interfaces;
using System.Linq;

namespace Phidelis.Repository
{
    public class EnrolmentRepository : BaseRepository<Enrolment>, IEnrolmentRepository
    {
        public EnrolmentRepository(PhidelisEFContext context) : base(context) { }

        public IQueryable<Enrolment> FindByName(string name)
        {
            return GetAll(p => p.Name == name);
        }
    }
}
