using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOH.MAIN.Models.Booking;

namespace SOH.PERSISTENCE.Data.Configuration
{
    internal class ConfigCalendarDetail : IEntityTypeConfiguration<SR_CalendarDetail>
    {
        public void Configure(EntityTypeBuilder<SR_CalendarDetail> builder)
        {
            builder.HasKey(x => new { x.idBooking, x.idCalendar });

                   builder.HasOne(x => x.Booking)
                   .WithMany() 
                   .HasForeignKey(x => x.idBooking);

            builder.HasOne(x => x.Calendar)
                   .WithMany()
                   .HasForeignKey(x => x.idCalendar);
        }
    }
}
