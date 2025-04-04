using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOH.MAIN.Models.Booking;

namespace SOH.PERSISTENCE.Data.Configuration
{
    internal class ConfigCalendar : IEntityTypeConfiguration<SR_Calendar>
    {
        public void Configure(EntityTypeBuilder<SR_Calendar> builder)
        {
            builder.HasKey(x => x.idCalendar);
        }
    }
}
