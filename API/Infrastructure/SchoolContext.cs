using System.Threading;
using System.Threading.Tasks;
using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure
{
    public class SchoolContext : DbContext, ISchoolContext
    {
        public SchoolContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SchoolClass> Classes { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolClass>().ToTable("Class");
            modelBuilder.Entity<Student>().ToTable("User");
        }
    }

}
