using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phidelis.Entities.Models;

namespace Phidelis.Repository.Mappings
{
    public class EnrolmentMap : IEntityTypeConfiguration<Enrolment>
    {
        public void Configure(EntityTypeBuilder<Enrolment> builder)
        {
            builder.ToTable("Enrolment");

            builder.HasKey(p => p.Id);

        }
    }
}
