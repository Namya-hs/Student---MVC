using Microsoft.EntityFrameworkCore;
using Student_CRUD.Models;

namespace Student_CRUD.Database
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }

        public DbSet<Students> Students { get; set; }
    }
}
