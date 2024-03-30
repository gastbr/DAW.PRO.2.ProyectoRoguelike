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
        string[] textoOpciones;
        public Cursor cursor;
        public Pausa()
        {
            x = 54;
            y = 12;
            textoOpciones = ["Continuar", "Abrir inventario", "Guardar y salir", "Salir"];
            cursor = new Cursor(x - 3, y, textoOpciones.Length);
        }

        public void DibujaMenu()
        {
            Partida.estado = Partida.Estado.Menu;
            Interfaz.LimpiaPantalla();
            for (int i = 0; i < textoOpciones.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine(textoOpciones[i]);
            }

            switch (Controles.DetectaTeclaMenu(cursor))
            {
                case 1:
                    Continuar();
                    break;
                case 2:
                    Inventario();
                    break;
                case 3:
                    GuardarSalir();
                    break;
                case 4:
                    Salir();
                    break;
            }
        }
        public void Continuar()
        {
            Partida.BucleJuego();
        }
        public void Inventario()
        {
            DibujaMenu();
            //Interfaz.LimpiaPantalla();
            //Cursor cursor = new Cursor(x - 3, y, Partida.protagonista.inventario.Count);
            //Console.SetCursorPosition(x, y);
            //for (int i = 0; i < Partida.protagonista.inventario.Count; i++)
            //{
            //    Console.SetCursorPosition(x, y + i);
            //    Console.WriteLine(Partida.protagonista.inventario[i]);
            //}
        }
        public void GuardarSalir()
        {
            Partida.GuardaPartida();
            Partida.Inicio();
        }
        public void Salir()
        {
            Partida.Inicio();
        }

    }
}
