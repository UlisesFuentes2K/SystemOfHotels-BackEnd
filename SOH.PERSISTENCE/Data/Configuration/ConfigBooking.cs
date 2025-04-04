using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOH.MAIN.Models.Booking;

namespace SOH.PERSISTENCE.Data.Configuration
{
    internal class ConfigBooking : IEntityTypeConfiguration<SR_Booking>
    {
        public void Configure(EntityTypeBuilder<SR_Booking> builder)
        {
            builder.HasKey(x => x.idBooking);
        }
    }
}
