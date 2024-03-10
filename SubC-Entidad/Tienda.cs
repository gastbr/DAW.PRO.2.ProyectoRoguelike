using DAW.PRO._2.ProyectoRoguelike.Clases;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.SubC_Entidad
{
    internal class Tienda : Entidad
    {
        public Tienda()
        {
            nombre = "";
            x = 0;
            y = 0;
            direccion = Direccion.derecha;
            oro = 1025648;
            nivel = 4800;
            vidaMax = 7;
            vidaActual = 7;
            ataque = 8650;
            defensa = 3700;
        }
        public void habla() { }
        public void bienvenida() { }
        public void abreVenta() { }
        public void abreCompra() { }
        public void vende() { }
        public void compra() { }
        public void contraataca() { }
    }
}
