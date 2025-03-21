using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOH.MAIN.Models.Booking
{
    public enum SR_State
    {
        Resevada,
        Reservada_y_Modificada,
        Cancelada,
        Tomada,
        No_tomada,
        En_pausa,
        Plazo_incompleto,
        Extendida
    }
}
