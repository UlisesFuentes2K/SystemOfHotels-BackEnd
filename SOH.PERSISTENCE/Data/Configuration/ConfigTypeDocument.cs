using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOH.MAIN.Models.Customer;

namespace SOH.PERSISTENCE.Data.Configuration
{
    internal class ConfigTypeDocument : IEntityTypeConfiguration<SR_TypeDocument>
    {
        public void Configure(EntityTypeBuilder<SR_TypeDocument> builder)
        {
            builder.HasKey(x => x.idTypeDocument);
        }
    }
}
