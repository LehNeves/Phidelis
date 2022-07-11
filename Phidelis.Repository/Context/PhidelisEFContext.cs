using Microsoft.EntityFrameworkCore;
using Phidelis.Entities.Models;
using Phidelis.Repository.Context.Interface;
using Phidelis.Repository.Mappings;

namespace Phidelis.Repository.Context
{
    public class PhidelisEFContext : DbContext, IPhidelisEFContext
    {
        public PhidelisEFContext(DbContextOptions<PhidelisEFContext> options): base(options) { }

        public DbSet<Enrolment> Enrolments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EnrolmentMap());
        }
    }
}
