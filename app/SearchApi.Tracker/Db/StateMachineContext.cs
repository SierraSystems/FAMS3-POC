using Microsoft.EntityFrameworkCore;
using SearchApi.Tracker.Tracking;

namespace SearchApi.Tracker.Db
{
    public class StateMachineContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public StateMachineContext(DbContextOptions<StateMachineContext> options) : base(options)
        {

        }

        public DbSet<Investigation> Investigations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InvestigationTypeConfiguration());
        }

    }
}