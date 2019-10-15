using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchApi.Tracker.Tracking;

namespace SearchApi.Tracker.Db
{
    public class InvestigationTypeConfiguration : IEntityTypeConfiguration<Investigation>
    {
        public void Configure(EntityTypeBuilder<Investigation> builder)
        {
            builder.HasKey(x => x.CorrelationId);
            builder.ForNpgsqlUseXminAsConcurrencyToken();
        }
    }
}