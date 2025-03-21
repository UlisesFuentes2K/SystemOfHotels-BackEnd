using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOH.MAIN.Models.Payments
{
    public class SR_Pay
    {
        public int idPay { get; set; }
        public float pay { get; set; }

        //Claves foraneas como propiedad
        [ForeignKey("SR_TypePay")]
        public SR_TypePay typePay { get; set; }
        public int idTypePay { get; set; }
    }
}
