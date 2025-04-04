using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOH.MAIN.Models.Employee;
using SOH.MAIN.Models.Payments;

namespace SOH.PERSISTENCE.Data.Configuration
{
    internal class ConfigBil : IEntityTypeConfiguration<SR_Bill>
    {
        public void Configure(EntityTypeBuilder<SR_Bill> builder)
        {
            builder.HasKey(x => x.idBill);
        }
    }
}
