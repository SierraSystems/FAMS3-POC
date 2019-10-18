using Microsoft.EntityFrameworkCore;
using SearchApi.Core.Providers;
using SearchApi.Tracker.Tracking;

namespace SearchApi.Tracker.Db
{
    /// <summary>
    /// Represents the state machine context
    /// </summary>
    public class StateMachineContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public StateMachineContext(DbContextOptions<StateMachineContext> options) : base(options)
        {

        }

        /// <summary>
        /// Tracks the Investigations
        /// </summary>
        public DbSet<Investigation> Investigations { get; set; }

        /// <summary>
        /// Tracks the providers
        /// </summary>
        public DbSet<Provider> Providers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InvestigationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProviderConfiguration());
        }

    }
}