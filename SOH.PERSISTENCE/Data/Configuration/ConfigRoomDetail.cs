using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOH.MAIN.Models.Booking;

namespace SOH.PERSISTENCE.Data.Configuration
{
    internal class ConfigRoomDetail : IEntityTypeConfiguration<SR_RoomDetail>
    {
        public void Configure(EntityTypeBuilder<SR_RoomDetail> builder)
        {
            builder.HasKey(x => new { x.idBooking, x.idRoom });

            builder.HasOne(x => x.Booking)
                   .WithMany()
                   .HasForeignKey(x => x.idBooking);

            builder.HasOne(x => x.Room)
                   .WithMany()
                   .HasForeignKey(x => x.idRoom);
        }
    }
}
