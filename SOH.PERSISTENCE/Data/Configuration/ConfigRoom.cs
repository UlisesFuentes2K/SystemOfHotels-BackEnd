using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOH.MAIN.Models.Booking;
using SOH.MAIN.Models.Payments;

namespace SOH.PERSISTENCE.Data.Configuration
{
    internal class ConfigRoom : IEntityTypeConfiguration<SR_Room>
    {
        public void Configure(EntityTypeBuilder<SR_Room> builder)
        {
            builder.HasKey(x => x.idRoom);
        }
    }
}
