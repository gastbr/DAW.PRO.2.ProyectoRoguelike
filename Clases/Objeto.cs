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
        public int id;
        public int x;
        public int y;
        public int valor;
        public int efecto;
        public bool spawneado = false;
        public void Dibuja()
        {
            if (spawneado)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("o");
            }
        }
        public void Spawn(int id, int x, int y)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            spawneado = true;
        }
        public virtual void Aplica(Entidad jugador)
        {
            // aplicar el efecto (+vida, +fuerza o +defensa) a la stat correspondiente del jugador correspondiente
        }
    }
}
