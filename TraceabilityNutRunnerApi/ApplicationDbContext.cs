using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TraceabilityNutRunnerApi
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TighteningResult> TighteningResults { get; set; }
        public DbSet<TighteningDetail> TighteningDetails { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
