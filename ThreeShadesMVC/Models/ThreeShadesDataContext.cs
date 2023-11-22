using Microsoft.EntityFrameworkCore;
using ThreeShades.MVC.Models;

namespace ThreeShades.MVC
{
    public class ThreeShadesDataContext : DbContext
    {
        public ThreeShadesDataContext(DbContextOptions<ThreeShadesDataContext> options) : base(options)
        {
        }

        public DbSet<Duty> Duties { get; set; }
    }
}
