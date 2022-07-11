using Phidelis.Entities.Interfaces;
using System;

namespace Phidelis.Entities.Models
{
    public class Enrolment: IBaseModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime EnrolmentDate { get; private set; }

        public Enrolment() { }

        public static Enrolment Buider(int id, string name, DateTime enrolmentDate)
        {
            return new Enrolment()
            {
                Id = id,
                Name = name,
                EnrolmentDate = enrolmentDate
            };
        }

        public void SetNome(string name)
        {
            Name = name;
        }
    }
}
