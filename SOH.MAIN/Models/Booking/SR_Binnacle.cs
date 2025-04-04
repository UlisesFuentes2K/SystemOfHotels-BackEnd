using System.ComponentModel.DataAnnotations.Schema;

namespace SOH.MAIN.Models.Booking
{
    public class SR_Binnacle
    {
        public int idBinnacle { get; set; }
        public string description { get; set; }
        public DateTime insertDate { get; set; }
        public DateTime modificationDate { get; set; }

        //Claves foraneas como propiedad
        [ForeignKey("idBooking")]
        public int idBooking { get; set; }
        public SR_Booking? Booking { get; set; }

    }
}
