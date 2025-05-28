using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOH.MAIN.Models.Booking;

namespace SOH.PERSISTENCE.Data.Configuration
{
    internal class ConfigState : IEntityTypeConfiguration<SR_State>
    {
        public void Configure(EntityTypeBuilder<SR_State> builder)
        {
            builder.HasKey(x => x.idState);
        }
    }
}
