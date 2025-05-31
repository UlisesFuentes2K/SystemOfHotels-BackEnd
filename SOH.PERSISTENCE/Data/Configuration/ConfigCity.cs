using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOH.MAIN.Models.Customer;

namespace SOH.PERSISTENCE.Data.Configuration
{
    internal class ConfigCity : IEntityTypeConfiguration<SR_City>
    {
        public void Configure(EntityTypeBuilder<SR_City> builder)
        {
            builder.HasKey(x => x.idCity);
        }
    }
}
