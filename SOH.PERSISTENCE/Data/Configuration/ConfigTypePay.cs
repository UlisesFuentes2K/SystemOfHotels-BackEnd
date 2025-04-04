using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOH.MAIN.Models.Employee;
using SOH.MAIN.Models.Payments;

namespace SOH.PERSISTENCE.Data.Configuration
{
    internal class ConfigTypePay : IEntityTypeConfiguration<SR_TypePay>
    {
        public void Configure(EntityTypeBuilder<SR_TypePay> builder)
        {
            builder.HasKey(x => x.idTypePay);
        }
    }
}
