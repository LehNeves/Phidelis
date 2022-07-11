using Phidelis.Entities.DTO;
using Phidelis.Entities.Interfaces;
using Phidelis.Entities.Models;
using Phidelis.Repository.Interfaces;
using Phidelis.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Phidelis.Service
{
    public class EnrolmentService : BaseService<IBaseDTO<Enrolment>, Enrolment>, IEnrolmentService
    {
        readonly IEnrolmentRepository _repoEnrolment;

        public EnrolmentService(IEnrolmentRepository _repo)
            : base(_repo)
        {
            _repoEnrolment = _repo;
        }

        public IList<EnrolmentDTO> FindByName(string name)
        {
            return _repoEnrolment.FindByName(name).Select(p => new EnrolmentDTO(p)).ToList();
        }
    }
}
