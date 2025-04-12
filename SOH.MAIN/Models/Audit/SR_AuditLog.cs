using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOH.MAIN.Models.Audit
{
    public class SR_AuditLog
    {
        public int idAuditLog { get; set; }
        public int idUser { get; set; }
        public int idRole { get; set; }
        public string Action { get; set; }
        public string TableAffected { get; set; } 
        public int RecordId { get; set; } 
        public DateTime Timestamp { get; set; } 
        public string Details { get; set; }
    }
}
