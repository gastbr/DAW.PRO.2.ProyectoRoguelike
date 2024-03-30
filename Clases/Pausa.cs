using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.Clases
{
    internal class Pausa
    {
        int x;
        int y;
        string[] opciones;
        public Cursor cursor;
        public Pausa()
        {
            x = (Console.WindowHeight / 2) - 2;
            y = (Console.WindowWidth / 2) - 5;
            opciones = ["Continuar", "Abrir inventario", "Guardar y salir", "Salir"];
            cursor = new Cursor(x - 3, y, opciones.Length);
        }

        public void DibujaMenu()
        {
            Partida.estado = Partida.Estado.Menu;
            Interfaz.LimpiaPantalla();
            for (int i = 0; i < opciones.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine(opciones[i]);
            }
        }
        public void Continuar()
        {
            Partida.BucleJuego();
        }
        public void Inventario()
        {
            Interfaz.LimpiaPantalla();
            Cursor cursor = new Cursor(x - 3, y, Partida.protagonista.inventario.Count);
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < Partida.protagonista.inventario.Count; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine(Partida.protagonista.inventario[i]);
            }
            
        }
        public void GuardarSalir()
        {
            Partida.GuardaPartida();
            Partida.DibujaPortada();
        }
        public void Salir()
        {
            Partida.DibujaPortada();
        }

    }
}
