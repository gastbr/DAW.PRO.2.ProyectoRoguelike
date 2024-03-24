using DAW.PRO._2.ProyectoRoguelike.SubC_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.Clases
{
    internal static class Partida
    {
        static public Entidad protagonista;
        static public void dibujaPortada()
        {
            Console.CursorVisible = false;
        }
        static public void cargaPartida()
        {
            // Copiar parte de nuevaPartida()
            // Extraer profesion y datos de archivo de guardado
        }
        static public void guardaPartida()
        {
            // Guardar:
            // Tipo de personaje
            // Stats, equipo e inventario
            // Posición del jugador (x, y, salaActual)
            // Salas dibujadas? (si es posible)
        }
        static public void nuevaPartida(string nombre, Entidad.Profesion profesion)
        {
            switch (profesion)
            {
                case Entidad.Profesion.Guerrero: protagonista = new JugadorGuerrero(); break;
                case Entidad.Profesion.Mago: protagonista = new JugadorMago(); break;
                case Entidad.Profesion.Picaro: protagonista = new JugadorPicaro(); break;
            }
            // Recorta espacios (trim), limita a los primeros 9 caracteres y pone la primera letra mayúscula.
            nombre = nombre.Trim();
            nombre = nombre.Substring(0, 9);
            nombre = String.Concat(char.ToUpper(nombre[0]) + nombre.Substring(1).ToLower());
            protagonista.nombre = nombre;
            Mapa.addSala();
        }
    }
}
