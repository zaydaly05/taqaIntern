using Microsoft.EntityFrameworkCore;
using InGazAPI.Models;

namespace InGazAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Area> Areas { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Reading> Readings { get; set; }
        public DbSet<WorkingLine> WorkingLines { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
