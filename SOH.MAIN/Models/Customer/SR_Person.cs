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
        public string numberDocument { get; set; }
        public DateTime? dateCreation { get; set; }
        public DateTime? dateModify { get; set; }


        //Enlace de uno a uno de Persona a Empleado
        public SR_Employee Employee { get; set; }

        //Enlace de uno a muchos de tipo de documento a persona
        [ForeignKey("idTypeDocument")]
        public SR_TypeDocument? TypeDocument { get; set; }
        public int idTypeDocument { get; set; }

        //Enlace de uno a muchos de genero a persona
        [ForeignKey("idGender")]
        public SR_Gender? Gender { get; set; }
        public int idGender { get; set; }

        //Enlace de uno a uno de Persona a Usuario
        [ForeignKey("idPerson")]
        public SR_Users Users { get; set; }

        [ForeignKey("idTypePerson")]
        public SR_TypePerson? typePerson { get; set; }
        public int idTypePerson { get; set; }

        [ForeignKey("idCity")]
        public SR_City? City { get; set; }
        public int idCity { get; set; }

        // Relación de una persona a un contactos de telefono (Home, Office, cellphone)
        public ICollection<SR_Contacts> Contacts { get; set; }
    }
}
