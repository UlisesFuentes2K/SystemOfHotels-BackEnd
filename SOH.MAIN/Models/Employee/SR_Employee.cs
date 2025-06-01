using SOH.MAIN.Models.Customer;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SOH.MAIN.Models.Employee
{
    public class SR_Employee
    {
        public int idEmployee { get; set; } 
        public DateTime? dateCreation { get; set; }
        public DateTime? dateModify { get; set; }

        //Enlace de uno a muchos de Shift a Employee
        [ForeignKey("idShift")]
        public SR_Shift? Shift { get; set; }
        public int idShift { get; set; }

        // Claves Foraneas como propiedades.
        [ForeignKey("idTypeEmployee")]
        public SR_TypeEmployee? TypeEmployee { get; set; }
        public int idTypeEmployee { get; set; }

        //Enlace de uno a uno de EMployee a Person
        [ForeignKey("idPerson")]
        public int idPerson { get; set; }

        [JsonIgnore]
        public SR_Person? Person { get; set; }
    }
}
