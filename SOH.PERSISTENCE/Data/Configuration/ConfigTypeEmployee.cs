using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOH.MAIN.Models.Booking;
using SOH.MAIN.Models.Employee;

namespace SOH.PERSISTENCE.Data.Configuration
{
    internal class ConfigTypeEmployee : IEntityTypeConfiguration<SR_TypeEmployee>
    {
        public void Configure(EntityTypeBuilder<SR_TypeEmployee> builder)
        {
            builder.HasKey(x => x.idTypeEmployee);
        }
    }
}
