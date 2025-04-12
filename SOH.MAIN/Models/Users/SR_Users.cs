using Microsoft.AspNetCore.Identity;
using SOH.MAIN.Models.Customer;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOH.MAIN.Models.Users
{
    public class SR_Users : IdentityUser
    {
        // Relación 1:1 con Persona
        [ForeignKey("idPerson")]
        public SR_Person Person { get; set; }
        public int idPerson { get; set; }
    }
}
