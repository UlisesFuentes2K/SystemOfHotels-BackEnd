using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOH.MAIN.Models.Booking
{
    public class SR_RoomDetail
    {
        public int idRoomDetail { get; set; }

        //Claves foraneas como propiedad
        [ForeignKey("SR_Booking")]
        public SR_Booking Booking { get; set; }
        public int idBooking { get; set; }

        [ForeignKey("SR_Room")]
        public SR_Room? Room { get; set; }
        public int idRoom { get; set; }
    }
}
