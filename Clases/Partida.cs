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
        static public void DibujaPortada()
        {
            Console.CursorVisible = false;
        }
        static public void CargaPartida()
        {
            // Copiar parte de nuevaPartida()
            // Extraer profesion y datos de archivo de guardado
        }
        static public void GuardaPartida()
        {
            // Guardar:
            // Tipo de personaje
            // Stats, equipo e inventario
            // Posición del jugador (x, y, salaActual)
            // Salas dibujadas? (si es posible)
        }
        static public void NuevaPartida(string nombre, Entidad.Profesion profesion)
        {
            // Limpia la pantalla entera en cada nueva partida
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                for (int j = 0; j < Console.WindowHeight; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }
            switch (profesion)
            {
                case Entidad.Profesion.Guerrero: protagonista = new JugadorGuerrero(); break;
                case Entidad.Profesion.Mago: protagonista = new JugadorMago(); break;
            }
            nombre = nombre.Trim();
            nombre = nombre.Substring(0, Math.Min(nombre.Length, 9));
            nombre = String.Concat(char.ToUpper(nombre[0]) + nombre.Substring(1).ToLower());
            protagonista.nombre = nombre;
            Mapa.AddSala();
        }
    }
}
