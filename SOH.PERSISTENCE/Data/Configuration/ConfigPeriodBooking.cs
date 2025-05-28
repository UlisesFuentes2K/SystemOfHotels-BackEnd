using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOH.MAIN.Models.Booking;

namespace SOH.PERSISTENCE.Data.Configuration
{
    internal class ConfigPeriodBooking : IEntityTypeConfiguration<SR_PeriodBooking>
    {
        public void Configure(EntityTypeBuilder<SR_PeriodBooking> builder)
        {
            builder.HasKey(x => x.idPeriodBooking);
        }
    }
}
