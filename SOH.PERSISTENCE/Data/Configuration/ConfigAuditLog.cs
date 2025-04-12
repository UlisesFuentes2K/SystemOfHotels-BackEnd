using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOH.MAIN.Models.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOH.PERSISTENCE.Data.Configuration
{
    internal class ConfigAuditLog : IEntityTypeConfiguration<SR_AuditLog>
    {
        public void Configure(EntityTypeBuilder<SR_AuditLog> builder)
        {
            builder.HasKey(x => x.idAuditLog);
        }
    }
}
