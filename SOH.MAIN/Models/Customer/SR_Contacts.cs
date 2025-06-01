using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SOH.MAIN.Models.Customer
{
    public class SR_Contacts
    {
        public int idContacts { get; set; }
        public string cellephone { get; set; }
        public string? telephoneHome { get; set; }
        public string? telephoneOffice { get; set; }

        // Claves Foaraneas como propiedades.
        [ForeignKey("idPerson")]
        public int idPerson { get; set; }

        [JsonIgnore]
        public SR_Person? Person { get; set; }
    }
}
