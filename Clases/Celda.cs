using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.Clases
{
    internal abstract class Celda
    {
        public string nombre;
        public bool ocupada;
        public int x;
        public int y;
        public Type? entidad;
        public Type? objeto;
        public int? idEntidad;
        public int? idObjeto;
        public Celda(int x, int y)
        {
            ocupada = false;
            entidad = null;
            objeto = null;
            idEntidad = null;
            idObjeto = null;
            this.x = x;
            this.y = y;
        }
        public abstract void Dibuja();
    }
}
