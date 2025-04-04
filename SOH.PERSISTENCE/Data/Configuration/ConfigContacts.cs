using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOH.MAIN.Models.Customer;

namespace SOH.PERSISTENCE.Data.Configuration
{
    internal class ConfigContacts : IEntityTypeConfiguration<SR_Contacts>
    {
        public void Configure(EntityTypeBuilder<SR_Contacts> builder)
        {
            builder.HasKey(x => x.idContacts);
        }
    }
}
