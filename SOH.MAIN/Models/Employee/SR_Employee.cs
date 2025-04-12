using SOH.MAIN.Models.Customer;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOH.MAIN.Models.Employee
{
    public class SR_Employee
    {
        public int idEmployee { get; set; } 
        public SR_Shift shift { get; set; }
        public bool isActive { get; set; }


        //Enlace de uno a uno de EMployee a Person
        [ForeignKey("idPerson")]
        public SR_Person? Person { get; set; }
        public int idPerson { get; set; }

        // Claves Foraneas como propiedades.
        [ForeignKey("idTypeEmployee")]
        public SR_TypeEmployee? TypeEmployee { get; set; }
        public int idTypeEmployee { get; set; }
    }
}
