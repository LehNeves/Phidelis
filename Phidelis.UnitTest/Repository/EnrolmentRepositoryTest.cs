using Microsoft.EntityFrameworkCore;
using Phidelis.Entities.Models;
using Phidelis.Repository;
using Phidelis.Repository.Context;
using System;
using System.Linq;
using Xunit;

namespace Phidelis.UnitTest.Repository
{
    public class EnrolmentRepositoryTest
    {
        [Fact]
        public void TestingFilteringByName_HasToComplete()
        {
            var options = new DbContextOptionsBuilder<PhidelisEFContext>()
            .UseInMemoryDatabase(databaseName: "EnrolmentMemoryDatabase")
            .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new PhidelisEFContext(options))
            {
                context.Enrolments.Add(Enrolment.Buider(1, "XPTO", DateTime.Now));
                context.Enrolments.Add(Enrolment.Buider(2, "Fulano", DateTime.Now));
                context.Enrolments.Add(Enrolment.Buider(3, "Beltrano", DateTime.Now));
                context.Enrolments.Add(Enrolment.Buider(4, "Sicrano", DateTime.Now));
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new PhidelisEFContext(options))
            {
                EnrolmentRepository enrolmentRepository = new EnrolmentRepository(context);

                var result = enrolmentRepository.FindByName("XPTO");

                Assert.Equal(1, result.Count());
            }
        }
    }
}
