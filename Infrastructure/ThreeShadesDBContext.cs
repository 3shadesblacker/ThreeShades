using Microsoft.EntityFrameworkCore;
using DataModels;

namespace DataContext
{
    public class ThreeShadesDBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ThreeShadesDBContext(DbContextOptions<ThreeShadesDBContext> options) : base(options)
        {
        }
        public DbSet<DutyModel> Duties { get; set; }
        public DbSet<DutyStateModel> DutyStates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
