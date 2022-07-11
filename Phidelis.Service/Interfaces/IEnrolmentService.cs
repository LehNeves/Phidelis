using Phidelis.Entities.DTO;
using Phidelis.Entities.Interfaces;
using Phidelis.Entities.Models;
using System.Collections.Generic;

namespace Phidelis.Service.Interfaces
{
    public interface IEnrolmentService: IBaseService<IBaseDTO<Enrolment>, Enrolment>
    {
        IList<EnrolmentDTO> FindByName(string name);
    }
}
