using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOH.MAIN.Models.Booking;
using SOH.MAIN.Models.Customer;

namespace SOH.PERSISTENCE.Data.Configuration
{
    internal class ConfigPromotion : IEntityTypeConfiguration<SR_Promotion>
    {
        public void Configure(EntityTypeBuilder<SR_Promotion> builder)
        {
            builder.HasKey(x => x.idPromotion);
        }
    }
}
