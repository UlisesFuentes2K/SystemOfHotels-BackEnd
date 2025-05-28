using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOH.MAIN.Models.Employee;

namespace SOH.PERSISTENCE.Data.Configuration
{
    internal class ConfigShift : IEntityTypeConfiguration<SR_Shift>
    {
        public void Configure(EntityTypeBuilder<SR_Shift> builder)
        {
            builder.HasKey(x => x.idShift);
        }
    }
}
