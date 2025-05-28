using SOH.MAIN.Models.Customer;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOH.MAIN.Models.Booking
{
    public class SR_Booking
    {
        public int idBooking { get; set; }
        public int durationBooking { get; set; }
        public bool isActive { get; set; }
        public int? idPromotion { get; set; }

        //Claves foraneas como propiedades
        [ForeignKey("idPerson")]
        public int idPerson { get; set; }
        public SR_Person SR_Person { get; set; }

        //Claves foraneas como propiedades
        [ForeignKey("idPeriodBooking")]
        public SR_PeriodBooking? PeriodBooking { get; set; }
        public int idPeriodBooking { get; set; }
    }
}
