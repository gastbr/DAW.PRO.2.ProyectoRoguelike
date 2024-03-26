using DAW.PRO._2.ProyectoRoguelike.Clases;
using DAW.PRO._2.ProyectoRoguelike.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.SubC_Entidad
{
    internal class EnemigoGuerrero : Entidad, IGuerrero
    {
        public EnemigoGuerrero()
        {
            nombre = "";
            x = 0;
            y = 0;
            preX = x;
            preY = y;
            salaActual = 0;
            profesion = Profesion.Guerrero;
            direccion = Direccion.derecha;
            oro = 0;
            nivel = 1;
            experiencia = 0;
            vidaMax = 45;
            vidaActual = 45;
            ataque = 5;
            defensa = 0;
        }
        public override void Dibuja()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ï");
        }
        public void atacaMelee()
        {
            throw new NotImplementedException();
        }

        public void defiende()
        {
            throw new NotImplementedException();
        }
    }
}
