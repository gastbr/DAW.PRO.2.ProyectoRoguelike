using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.Clases
{
    internal class Cursor
    {
        public int x;
        public int y;
        public int opcion;
        public int maxOpciones;

        public Cursor(int x, int y, int maxOpciones)
        {
            this.x = x;
            this.y = y;
            opcion = 1;
            this.maxOpciones = maxOpciones;
            Dibuja();
        }

        public void Mueve(Entidad.Direccion direccion)
        {
            if (direccion == Entidad.Direccion.abajo && opcion < maxOpciones)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("  ");
                y++;
                opcion++;
            }
            else if (direccion == Entidad.Direccion.arriba && opcion > 1)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("  ");
                y--;
                opcion--;
            }

            Dibuja();
        }
        public void Dibuja()
        {
            Console.SetCursorPosition(x, y);
            Console.Write("->");
        }
    }
}
