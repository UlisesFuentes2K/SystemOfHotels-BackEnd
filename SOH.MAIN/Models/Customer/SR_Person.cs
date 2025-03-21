using Microsoft.AspNetCore.Identity;
using SOH.MAIN.Models.Employee;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOH.MAIN.Models.Customer
{
    public class SR_Person : IdentityUser
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public string direction { get; set; }
        public SR_Gender gender { get; set; }
        public SR_Document document { get; set; }
        public string numberDocument { get; set; }


        //Enlace de uno a uno de Persona a Empleado
        public SR_Employee Employee { get; set; }

        // Claves foraneas como propiedades
        [ForeignKey("SR_Contacts")]
        public SR_Contacts? Contacts { get; set; }
        public int idContacts { get; set; }

        [ForeignKey("SR_TypePerson")]
        public SR_TypePerson? typePerson { get; set; }
        public int idTypePerson { get; set; }

        [ForeignKey("SR_City")]
        public SR_City? City { get; set; }
        public int idCity { get; set; }
    }
}
