using DAW.PRO._2.ProyectoRoguelike.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.Interfaces
{
    internal interface IJugador
    {
        public void UsaObjeto(Objeto objeto);
        public void RecogeObjeto(Objeto objeto);
        public void DesechaObjeto(Objeto objeto);
        public void Entra(Celda puerta);
        public void Examina();
    }
}
