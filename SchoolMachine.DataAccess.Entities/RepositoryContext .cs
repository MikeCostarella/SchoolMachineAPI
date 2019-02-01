using Microsoft.EntityFrameworkCore;
using SchoolMachine.DataAccess.Entities.Models;

namespace SchoolMachine.DataAccess.Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<School> Schools { get; set; }
        public DbSet<SchoolStudent> SchoolStudents { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
