using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOH.MAIN.Models.Booking;

namespace SOH.PERSISTENCE.Data.Configuration
{
    internal class ConfigBinnacle : IEntityTypeConfiguration<SR_Binnacle>
    {
        public void Configure(EntityTypeBuilder<SR_Binnacle> builder)
        {
            builder.HasKey(x => x.idBinnacle);
        }
    }
}
