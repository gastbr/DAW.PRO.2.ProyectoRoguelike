using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAW.PRO._2.ProyectoRoguelike.Clases
{
    internal abstract class Objeto
    {
        public string nombre;
        public int valor;
        public int efecto;
        public int x;
        public int y;
        public bool spawneado = false;
        public void Dibuja()
        {
            if (spawneado)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("·");
            }
        }
        public void Spawn(int x, int y)
        {
            this.x = x;
            this.y = y;
            spawneado = true;
        }
        public void Aplica(Entidad jugador, int stat)
        {
            // aplicar el efecto (+vida, +fuerza o +defensa) a la stat correspondiente del jugador correspondiente
        }
    }
}
