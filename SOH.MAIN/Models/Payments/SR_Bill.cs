using SOH.MAIN.Models.Booking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOH.MAIN.Models.Payments
{
    public class SR_Bill
    {
        public int idBill { get; set; }
        public float Iva { get; set; }
        public DateTime emissionDate { get; set; }
        public int idRecharge { get; set; }

        //Claves foraneas como propiedad
        [ForeignKey("SR_Booking")]
        public SR_Booking? Booking { get; set; }
        public int idBooking { get; set; }

        [ForeignKey("SR_TypePay")]
        public SR_Pay? Pay { get; set; }
        public int idTypePay { get; set; }
    }
}
