using DAW.PRO._2.ProyectoRoguelike.Clases;
using DAW.PRO._2.ProyectoRoguelike.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.SubC_Entidad
{
    internal class EnemigoPicaro : Entidad, IPicaro
    {
        public EnemigoPicaro()
        {
            nombre = "";
            x = 0;
            y = 0;
            direccion = Direccion.derecha;
            oro = 0;
            nivel = 1;
            vidaMax = 25;
            vidaActual = 25;
            ataque = 2;
            defensa = 0;
        }

        public void atacaSigilo()
        {
            throw new NotImplementedException();
        }

        public void poneTrampa()
        {
            throw new NotImplementedException();
        }

        public void recogeTrampa()
        {
            throw new NotImplementedException();
        }
    }
}
