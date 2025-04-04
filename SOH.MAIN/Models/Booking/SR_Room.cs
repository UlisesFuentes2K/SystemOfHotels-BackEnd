using System.ComponentModel.DataAnnotations.Schema;

namespace SOH.MAIN.Models.Booking
{
    public class SR_Room
    {
        public int idRoom { get; set; }
        public int numberRoom { get; set; }
        public bool isActive { get; set; }

        //Claves foraneas como propiedad
        [ForeignKey("idCategoryRoom")]
        public SR_CategoryRoom CategoryRoom { get; set; }
        public int idCategoryRoom { get; set; }
    }
}
