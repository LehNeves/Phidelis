using Moq;
using Phidelis.Entities.DTO;
using Phidelis.Entities.Models;
using Phidelis.Repository.Interfaces;
using Phidelis.Service;
using System;
using Xunit;

namespace Phidelis.UnitTest.Service
{
    public class EnrolmentServiceTest
    {
        Mock<IEnrolmentRepository> _repoFake;

        public EnrolmentServiceTest()
        {
            _repoFake = new Mock<IEnrolmentRepository>();
        }

        [Fact]
        public void TestingUpdateMethod_HasToComplete()
        {
            var service = new EnrolmentService(_repoFake.Object);

            var obj = new EnrolmentDTO() { Id = 1, Name = "XPTO", EnrolmentDate = DateTime.Now };

            _repoFake.Setup(s => s.Update(It.IsAny<int>(), It.IsAny<Enrolment>()));

            service.Update(obj.Id.Value, obj);

            _repoFake.Verify(v => v.Update(It.IsAny<int>(), It.IsAny<Enrolment>()));
        }

        [Fact]
        public void TestingUpdateMethod_HasToFail()
        {
            var service = new EnrolmentService(_repoFake.Object);

            var obj = new EnrolmentDTO() { Id = 0, Name = "XPTO", EnrolmentDate = DateTime.Now };

            Assert.Throws<ArgumentException>(() => service.Update(obj.Id.Value, obj));
        }
    }
}
