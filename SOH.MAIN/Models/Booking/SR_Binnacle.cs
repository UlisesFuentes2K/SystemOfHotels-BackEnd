using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOH.MAIN.Models.Booking
{
    public class SR_Binnacle
    {
        public int idBinnacle { get; set; }
        public string description { get; set; }
        public DateTime insertDate { get; set; }
        public DateTime modificationDate { get; set; }

        //Claves foraneas como propiedad
        [ForeignKey("SR_State")]
        public SR_State? State { get; set; }
        public int idState { get; set; }

        [ForeignKey("SR_Booking")]
        public SR_Booking? Booking { get; set; }
        public int idBooking { get; set; }

    }
}
