using Microsoft.AspNetCore.Identity;
using SOH.MAIN.Models.Employee;
using SOH.MAIN.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOH.MAIN.Models.Customer
{
    public class SR_Person
    {
        public int idPerson { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string direction { get; set; }
        public SR_Gender gender { get; set; }
        public SR_Document document { get; set; }
        public string numberDocument { get; set; }


        //Enlace de uno a uno de Persona a Empleado
        public SR_Employee Employee { get; set; }

        //Enlace de uno a uno de Persona a Usuario
        public SR_Users Users { get; set; }

        [ForeignKey("idTypePerson")]
        public SR_TypePerson? typePerson { get; set; }
        public int idTypePerson { get; set; }

        [ForeignKey("idCity")]
        public SR_City? City { get; set; }
        public int idCity { get; set; }
    }
}
