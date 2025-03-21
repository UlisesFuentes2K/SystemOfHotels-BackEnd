using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOH.MAIN.Models.Booking
{
    public class SR_CalendarDetail
    {
        public int idCalendarDetail { get; set; }

        //Claves Foraneas como propiedad
        [ForeignKey("SR_Calendar")]
        public SR_Calendar? Calendar { get; set; }
        public int idCalendar { get; set; }

        [ForeignKey("SR_Booking")]
        public SR_Booking Booking { get; set; }
        public int idBooking { get; set; }
    }
}
