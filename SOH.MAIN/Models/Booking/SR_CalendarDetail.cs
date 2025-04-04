using System.ComponentModel.DataAnnotations.Schema;

namespace SOH.MAIN.Models.Booking
{
    public class SR_CalendarDetail
    {
        //Claves Foraneas como propiedad
        [ForeignKey("idCalendar")]
        public SR_Calendar? Calendar { get; set; }
        public int idCalendar { get; set; }

        [ForeignKey("idBooking")]
        public SR_Booking Booking { get; set; }
        public int idBooking { get; set; }
    }
}
