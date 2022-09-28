using Microsoft.EntityFrameworkCore;
using Student_Web_Api.Models.Domain;

namespace Student_Web_Api.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Marks> Marks { get; set; }
    }
}
