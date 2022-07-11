using Phidelis.Entities.Interfaces;
using Phidelis.Entities.Models;
using System;

namespace Phidelis.Entities.DTO
{
    public class EnrolmentDTO: IBaseDTO<Enrolment>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime EnrolmentDate { get; set; }

        public EnrolmentDTO()
        {
        }

        public EnrolmentDTO(Enrolment enrolment)
        {
            Id = enrolment.Id;
            Name = enrolment.Name;
            EnrolmentDate = enrolment.EnrolmentDate;
        }

        public Enrolment ConvertToModel()
        {
            return Enrolment.Buider(Id.GetValueOrDefault(), Name, EnrolmentDate);
        }
    }
}
