using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOH.MAIN.Models.Booking;

namespace SOH.PERSISTENCE.Data.Configuration
{
    internal class ConfigCategoryRoom : IEntityTypeConfiguration<SR_CategoryRoom>
    {
        public void Configure(EntityTypeBuilder<SR_CategoryRoom> builder)
        {
            builder.HasKey(x => x.idCategoryRoom);
        }
    }
}
