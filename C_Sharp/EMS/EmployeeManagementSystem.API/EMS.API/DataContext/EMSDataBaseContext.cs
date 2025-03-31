using EMS.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.DataContext
{
    public class EMSDataBaseContext : DbContext
    {
        public EMSDataBaseContext(DbContextOptions<EMSDataBaseContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Salary> Salaries { get; set; }

        public DbSet<PersonDetail> PersonDetails { get; set; }
    }
}
