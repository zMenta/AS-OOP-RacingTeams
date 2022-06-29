using AS_OOP_RacingTeams.Data.Types;
using AS_OOP_RacingTeams.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AS_OOP_RacingTeams.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new JobMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
        }

    }
}