using SOH.MAIN.Models.Customer;

namespace SOH.CORE.Dto
{
    public class RegisterData
    {
        public List<SR_Gender> Gender { get; set; }
        public List<SR_Country> Country { get; set; }
        public List<SR_City> City { get; set; }
        public List<SR_TypeDocument> TypeDocument { get; set; }
    }
}
