using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOH.MAIN.Models.Booking;
using SOH.MAIN.Models.Payments;

namespace SOH.PERSISTENCE.Data.Configuration
{
    internal class ConfigRecharge : IEntityTypeConfiguration<SR_Recharge>
    {
        public void Configure(EntityTypeBuilder<SR_Recharge> builder)
        {
            builder.HasKey(x => x.idRecarge);
        }
    }
}
