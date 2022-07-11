using Microsoft.EntityFrameworkCore;
using Phidelis.Entities.Models;

namespace Phidelis.Repository.Context.Interface
{
    public interface IPhidelisEFContext
    {
        DbSet<Enrolment> Enrolments { get; }
    }
}
