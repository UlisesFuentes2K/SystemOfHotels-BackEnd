using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOH.MAIN.Models.Customer;
using System.Reflection.Emit;

namespace SOH.PERSISTENCE.Data.Configuration
{
    internal class ConfigCountry : IEntityTypeConfiguration<SR_Country>
    {
        public void Configure(EntityTypeBuilder<SR_Country> builder)
        {
            builder.HasKey(x => x.idCountry);
        }
    }
}
