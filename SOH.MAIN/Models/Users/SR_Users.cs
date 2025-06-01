using Microsoft.AspNetCore.Identity;
using SOH.MAIN.Models.Customer;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SOH.MAIN.Models.Users
{
    public class SR_Users : IdentityUser
    {
        public DateTime? dateCreation { get; set; }
        public DateTime? dateModify { get; set; }
        public bool isActive { get; set; }

        // Relación 1:1 con Persona
        [ForeignKey("idPerson")]
        public int idPerson { get; set; }

        [JsonIgnore]
        public SR_Person? Person { get; set; }
    }
}
