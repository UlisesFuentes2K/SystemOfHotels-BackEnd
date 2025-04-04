using SOH.MAIN.Models.Customer;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOH.MAIN.Models.Booking
{
    public class SR_Booking
    {
        public int idBooking { get; set; }
        public int durationBooking { get; set; }
        public SR_PeriodBooking period { get; set; }
        public bool isActive { get; set; }
        public int? idPromotion { get; set; }

        //Claves foraneas como propiedades
        [ForeignKey("idPerson")]
        public int idPerson { get; set; }
        public SR_Person SR_Person { get; set; }
    }
}
