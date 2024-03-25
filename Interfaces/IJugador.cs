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
        public void usaObjeto(Objeto objeto);
        public void recogeObjeto(Objeto objeto);
        public void entra(Celda puerta);
        public void interactua();
        public void compruebaEntorno();
    }
}
