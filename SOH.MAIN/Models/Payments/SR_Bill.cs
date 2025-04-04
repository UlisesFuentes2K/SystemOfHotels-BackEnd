using SOH.MAIN.Models.Booking;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOH.MAIN.Models.Payments
{
    public class SR_Bill
    {
        public int idBill { get; set; }
        public float pay { get; set; }
        public float Iva { get; set; }
        public DateTime emissionDate { get; set; }
        public int idRecharge { get; set; }

        //Claves foraneas como propiedad
        [ForeignKey("idBooking")]
        public SR_Booking? Booking { get; set; }
        public int idBooking { get; set; }

        [ForeignKey("idTypePay")]
        public SR_TypePay? TypePay { get; set; }
        public int idTypePay { get; set; }
    }
}
