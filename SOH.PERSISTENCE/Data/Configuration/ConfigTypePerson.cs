using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOH.MAIN.Models.Customer;
using SOH.MAIN.Models.Payments;

namespace SOH.PERSISTENCE.Data.Configuration
{
    internal class ConfigTypePerson : IEntityTypeConfiguration<SR_TypePerson>
    {
        public void Configure(EntityTypeBuilder<SR_TypePerson> builder)
        {
            builder.HasKey(x => x.idTypePerson);
        }
    }
}
