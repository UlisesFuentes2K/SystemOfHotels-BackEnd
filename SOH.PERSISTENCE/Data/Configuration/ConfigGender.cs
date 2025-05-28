using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOH.MAIN.Models.Customer;

namespace SOH.PERSISTENCE.Data.Configuration
{
    internal class ConfigGender : IEntityTypeConfiguration<SR_Gender>
    {
        public void Configure(EntityTypeBuilder<SR_Gender> builder)
        {
            builder.HasKey(x => x.idGender);
        }
    }
}
