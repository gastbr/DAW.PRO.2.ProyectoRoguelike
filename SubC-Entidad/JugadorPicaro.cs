using DAW.PRO._2.ProyectoRoguelike.Clases;
using DAW.PRO._2.ProyectoRoguelike.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.SubC_Entidad
{
    internal class JugadorPicaro : Entidad, IPicaro, IJugador
    {
        public JugadorPicaro()
        {
            nombre = "";
            x = 0;
            y = 0;
            preX = x;
            preY = y;
            salaActual = 0;
            direccion = Direccion.derecha;
            profesion = Profesion.Picaro;
            oro = 0;
            nivel = 1;
            experiencia = 0;
            vidaMax = 25;
            vidaActual = 25;
            ataque = 2;
            defensa = 0;
        }

        public void atacaSigilo()
        {
            throw new NotImplementedException();
        }

        public void compruebaEntorno()
        {
            throw new NotImplementedException();
        }

        public override void Dibuja()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("@");
        }

        public void entra(Celda puerta)
        {
            throw new NotImplementedException();
        }

        public void interactua()
        {
            throw new NotImplementedException();
        }

        public void poneTrampa()
        {
            throw new NotImplementedException();
        }

        public void recogeObjeto(Objeto objeto)
        {
            throw new NotImplementedException();
        }

        public void recogeTrampa()
        {
            throw new NotImplementedException();
        }

        public void usaObjeto(Objeto objeto)
        {
            throw new NotImplementedException();
        }
    }
}
