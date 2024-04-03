using DAW.PRO._2.ProyectoRoguelike.Clases;
using DAW.PRO._2.ProyectoRoguelike.Interfaces;
using DAW.PRO._2.ProyectoRoguelike.SubC_Celda;
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
            frases = File.ReadAllLines("./../../../Textos/FrasesMago");
        }

        public override void Ataca()
        {
            throw new NotImplementedException();
        }

        public void CreaPortal()
        {
            throw new NotImplementedException();
        }

        public void Cura()
        {
            throw new NotImplementedException();
        }

        public void Defiende()
        {
            throw new NotImplementedException();
        }

        public void Entra(Celda puerta)
        {
            if (puerta is Entrada)
            {
                if (salaActual > 0)
                {
                    salaActual--;
                    spawneado = false;
                    Mapa.SalaAnterior();
                    spawneado = true;
                }
                else
                {
                    Interfaz.Escribe(nombre, "\"Si me rajo ahora seré el hazmerreír del pueblo\".");
                }
            }
            if (puerta is Salida)
            {
                salaActual++;
                spawneado = false;
                Mapa.SiguienteSala();
                spawneado = true;
            }
        }

        public override void Examina()
        {
            if (ExaminaObjeto() is not null)
            {
                RecogeObjeto(ExaminaObjeto());
            }
            else if (ExaminaEntidad() is not null)
            {
                ExaminaEntidad().Habla();
            }
            else if (ExaminaCelda() is Entrada || ExaminaCelda() is Salida)
            {
                Entra(ExaminaCelda());
            }
            else if (ExaminaCelda() is not Suelo)
            {
                switch (ExaminaCelda())
                {
                    case Agua:
                        Habla("\"Un pequeño charco de agua. Dicen que las aguas de estas tierras son curativas\".");
                        break;
                    case Lava:
                        Habla("\"Lava. Como agua, pero muy caliente y burbujeante. Mejor no acercarse\".");
                        break;
                    case Muro:
                        Habla("\"Un muro. No es bonito, pero cumple su función. Quién sabe qué clase de errores ocurrirían si no existieran y yo pisara fuera de este mapa\".");
                        break;
                    case Trampa:
                        Habla("\"Parece una trampa para osos\".");
                        break;
                }
            }
            else
            {
                Habla();
            }
        }

        public void RecogeObjeto(Objeto objeto)
        {
            if (inventario.Count < 10)
            {
                inventario.Add(objeto);
            }
            else
            {
                Interfaz.Escribe("Info", "El inventario está lleno.");
            }
        }

        public void UsaObjeto(Objeto objeto)
        {
            throw new NotImplementedException();
        }

        public void DesechaObjeto(Objeto objeto)
        {
            throw new NotImplementedException();
        }

        public override void Dibuja()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("@");
        }
    }
}
