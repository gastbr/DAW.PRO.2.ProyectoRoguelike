using DAW.PRO._2.ProyectoRoguelike.Clases;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.SubC_Entidad
{
    internal class PNJ : Entidad
    {
        public PNJ()
        {
            nombre = File.ReadAllLines("./../../../Textos/NombresPNJ")[Partida.rng.Next(File.ReadAllLines("./../../../Textos/NombresPNJ").Length)];
            x = 0;
            y = 0;
            preX = x;
            preY = y;
            salaActual = 0;
            direccion = Direccion.derecha;
            profesion = Profesion.PNJ;
            oro = 0;
            nivel = 1;
            experiencia = 0;
            vidaMax = 15;
            vidaActual = 15;
            ataque = 3;
            defensa = 0;
            frases = File.ReadAllLines("./../../../Textos/FrasesPNJ");
        }
        public override void Dibuja()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("ï");
        }
    }
}
