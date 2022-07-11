using Phidelis.Entities.Models;
using System;
using Xunit;

namespace Phidelis.UnitTest.Model
{
    public class EnrolmentTest
    {
        [Fact]
        public void TestingBuilder_HasToComplete()
        {
            var dateNow = DateTime.Now;
            var enrolment = Enrolment.Buider(1, "XPTO", dateNow);

            Assert.IsType<Enrolment>(enrolment);
            Assert.Equal("XPTO", enrolment.Name);
            Assert.Equal(dateNow, enrolment.EnrolmentDate);
        }
    }
}
