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
        string frase;
        public PNJ()
        {
            nombre = "";
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
            frase = "";
        }
        public override void Dibuja()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Ï");
        }
        public void habla()
        {

        }
        public void setFrase(string frase) { this.frase = frase; }
        public string getFrase() { return this.frase; }
    }
}
