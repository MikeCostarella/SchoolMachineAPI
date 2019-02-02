using Microsoft.EntityFrameworkCore;
using SchoolMachine.DataAccess.Entities.Models;

namespace SchoolMachine.DataAccess.Entities
{
    public class RepositoryContext : DbContext
    {
        #region Constructors

        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        #endregion Constructors

        #region DbSet Methods

        public DbSet<School> Schools { get; set; }

        public DbSet<SchoolStudent> SchoolStudents { get; set; }

        public DbSet<Student> Students { get; set; }

        #endregion DbSet Methods
    }
}
