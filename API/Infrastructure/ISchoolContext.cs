using System.Threading;
using System.Threading.Tasks;
using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure
{
    public interface ISchoolContext
    {
        DbSet<SchoolClass> Classes { get; set; }
        DbSet<Student> Students { get; set; }
        Task<int> SaveChangesAsync(CancellationToken token);
    }
}