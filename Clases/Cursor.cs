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
        public int opcionActual;
        public int maxOpciones;
        public int[] opciones;

        public Cursor(int x, int y, int maxOpciones)
        {
            this.x = x;
            this.y = y;
            opcionActual = 1;
            this.maxOpciones = maxOpciones;
            Dibuja();
        }

        public int Confirmar()
        {
            return opcionActual;
        }
        public void Mueve(Entidad.Direccion direccion)
        {
            if (direccion == Entidad.Direccion.abajo && opcionActual < maxOpciones)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("  ");
                y++;
                opcionActual++;
            }
            else if (direccion == Entidad.Direccion.arriba && opcionActual > 1)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("  ");
                y--;
                opcionActual--;
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
