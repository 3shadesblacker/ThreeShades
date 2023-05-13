using I_did_those.Models;
using Microsoft.EntityFrameworkCore;

namespace I_did_those.Data
{
    public class IDidThoseDbContext : DbContext
    {
        public IDidThoseDbContext(DbContextOptions<IDidThoseDbContext> options) : base(options)
        {
        }
        public DbSet<Duty> Duties { get; set; }
    }
}