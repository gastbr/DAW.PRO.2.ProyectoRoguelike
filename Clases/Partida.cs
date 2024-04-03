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
        static public Estado estado;
        public enum Estado { Portada, Partida, Menu };
        static public Random rng = new Random();
        static public Entidad protagonista;
        static int xMenu;
        static int yMenu;
        public static void Inicio()
        {
            Interfaz.LimpiaPantalla();
            Console.CursorVisible = false;
            estado = Estado.Portada;

            string[] portadas = File.ReadAllLines("./../../../Textos/Portadas");
            List<string> portadaElegida = new List<string>();
            int numeroDePortadas = Int32.Parse(portadas[portadas.Length - 1].Substring(2, 1));
            int indicePortadaElegida = rng.Next(0, numeroDePortadas + 1);
            int indiceInicioPortada = -1;
            int indiceFinPortada = -1;
            int anchoPortada = 0;
            int altoPortada = 0;

            for (int i = 0; i < portadas.Length; i++)
            {
                if (portadas[i] == $"<{indicePortadaElegida}>")
                {
                    indiceInicioPortada = i + 1;
                }
                if (portadas[i] == $"</{indicePortadaElegida}>")
                {
                    indiceFinPortada = i - 1;
                }
            }

            for (int i = indiceInicioPortada; i <= indiceFinPortada; i++)
            {
                portadaElegida.Add(portadas[i]);
                altoPortada++;
                if (portadas[i].Length > anchoPortada)
                {
                    anchoPortada = portadas[i].Length;
                }
            }

            // Imprime la portada, centrándola vertical (dejando espacio para el menú) y horizontalmente
            for (int i = 0; i < portadaElegida.Count; i++)
            {
                Console.SetCursorPosition((120 / 2) - (anchoPortada / 2), 12 - (altoPortada / 2) + i);
                Console.Write(portadaElegida[i]);
            }

            xMenu = 55;
            yMenu = 29 - ((30 - altoPortada) / 2);

            Console.SetCursorPosition(xMenu, yMenu);
            Console.WriteLine("NUEVA PARTIDA");
            Console.SetCursorPosition(xMenu, yMenu + 1);
            Console.WriteLine("CONTINUAR PARTIDA");
            Console.SetCursorPosition(xMenu, yMenu + 2);
            Console.WriteLine("CAMBIAR PORTADA");
            Console.SetCursorPosition(xMenu, yMenu + 3);
            Console.WriteLine("SALIR");
            Controles.DetectaTeclaPortada(xMenu, yMenu);
            Partida.BucleJuego();
        }
        public static void BucleJuego()
        {
            Mapa.GetSala(protagonista.salaActual).DibujaSala();
            while (estado == Estado.Partida)
            {
                Interfaz.DibujaHUD();
                Mapa.GetSala(protagonista.salaActual).DibujaEntidades();
                Controles.DetectaTeclaJuego();
            }
            estado = Estado.Partida;
        }
        public static void CargaPartida()
        {
            // Copiar parte de nuevaPartida()
            // Extraer profesion y datos de archivo de guardado
        }
        public static void GuardaPartida()
        {
            // Guardar:
            // Tipo de personaje
            // Stats, equipo e inventario
            // Posición del jugador (x, y, salaActual)
            // Salas dibujadas? (si es posible)
        }
        public static void NuevaPartida(string nombre, Entidad.Profesion profesion)
        {
            Interfaz.LimpiaPantalla();
            Mapa.BorrarMapa();
            estado = Estado.Partida;

            switch (profesion)
            {
                case Entidad.Profesion.Guerrero: protagonista = new JugadorGuerrero(); break;
                case Entidad.Profesion.Mago: protagonista = new JugadorMago(); break;
            }

            // Si no se introduce nombre, se elige uno al azar de la lista de nombres.
            // Si se introduce nombre, se recortan los espacios en blanco, se cogen solo las primeras 9 letras y se pone la primera en mayúscula.

            if (nombre.Length == 0)
            {
                nombre = File.ReadAllLines("./../../../Textos/NombresPNJ")[Partida.rng.Next(File.ReadAllLines("./../../../Textos/NombresPNJ").Length)];
            }

            nombre = nombre.Trim();
            nombre = nombre.Substring(0, Math.Min(nombre.Length, 9));
            nombre = String.Concat(char.ToUpper(nombre[0]) + nombre.Substring(1).ToLower());
            protagonista.nombre = nombre;
            Mapa.AddSala();
        }
    }
}
