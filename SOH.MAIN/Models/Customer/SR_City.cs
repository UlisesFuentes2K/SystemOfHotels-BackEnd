using System.ComponentModel.DataAnnotations.Schema;

namespace SOH.MAIN.Models.Customer
{
    public class SR_City
    {
        public int idCity { get; set; }
        public string name { get; set; }

        [ForeignKey("idCountry")]
        public SR_Country? Country { get; set; }
        public int idCountry { get; set; }
    }
}
