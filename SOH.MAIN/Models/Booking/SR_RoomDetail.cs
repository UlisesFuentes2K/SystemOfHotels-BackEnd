using System.ComponentModel.DataAnnotations.Schema;

namespace SOH.MAIN.Models.Booking
{
    public class SR_RoomDetail
    {
        //Claves foraneas como propiedad
        [ForeignKey("idBooking")]
        public SR_Booking Booking { get; set; }
        public int idBooking { get; set; }

        [ForeignKey("idRoom")]
        public SR_Room? Room { get; set; }
        public int idRoom { get; set; }
    }
}
