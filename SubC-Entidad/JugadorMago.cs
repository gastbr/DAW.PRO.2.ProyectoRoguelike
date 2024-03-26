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
    internal class JugadorMago : Entidad, IMago, IJugador
    {
        public JugadorMago()
        {
            nombre = "";
            x = 0;
            y = 0;
            preX = x;
            preY = y;
            salaActual = 0;
            direccion = Direccion.derecha;
            profesion = Profesion.Mago;
            oro = 0;
            nivel = 1;
            experiencia = 0;
            vidaMax = 30;
            vidaActual = 30;
            ataque = 3;
            defensa = 0;
        }

        public void atacaDistancia()
        {
            throw new NotImplementedException();
        }

        public void compruebaEntorno()
        {
            throw new NotImplementedException();
        }

        public void creaPortal()
        {
            throw new NotImplementedException();
        }

        public void cura()
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

        public void recogeObjeto(Objeto objeto)
        {
            throw new NotImplementedException();
        }

        public void usaObjeto(Objeto objeto)
        {
            throw new NotImplementedException();
        }
    }
}
