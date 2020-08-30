using Lab9.DataLayer.Entities;
using System.Data.Entity;

namespace Lab9.DataLayer.EFContext
{
    class CoursesContext : DbContext
    {
        public CoursesContext(string name) : base(name)
        {
            Database.SetInitializer(new CoursesInitializer());
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
