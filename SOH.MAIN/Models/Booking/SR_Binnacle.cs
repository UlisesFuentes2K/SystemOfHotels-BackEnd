using System.ComponentModel.DataAnnotations.Schema;

namespace SOH.MAIN.Models.Booking
{
    public class SR_Binnacle
    {
        public int idBinnacle { get; set; }
        public string description { get; set; }
        public DateTime? insertDate { get; set; }
        public DateTime? modificationDate { get; set; }

        //Claves foraneas como propiedad
        [ForeignKey("idBooking")]
        public SR_Booking? Booking { get; set; }
        public int idBooking { get; set; }

        //Claves foraneas como propiedad
        [ForeignKey("idState")]
        public SR_State? State { get; set; }
        public int idState { get; set; }

    }
}
