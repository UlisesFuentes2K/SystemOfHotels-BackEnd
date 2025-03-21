using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOH.MAIN.Models.Booking
{
    public class SR_Room
    {
        public int idRoom { get; set; }
        public int numberRoom { get; set; }
        public bool isActive { get; set; }

        //Claves foraneas como propiedad
        [ForeignKey("SR_CategoryRoom")]
        public SR_CategoryRoom CategoryRoom { get; set; }
        public int idCategoryRoom { get; set; }
    }
}
