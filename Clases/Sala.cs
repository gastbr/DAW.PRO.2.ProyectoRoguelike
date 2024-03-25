using DAW.PRO._2.ProyectoRoguelike.SubC_Celda;
using DAW.PRO._2.ProyectoRoguelike.SubC_Entidad;
using DAW.PRO._2.ProyectoRoguelike.SubC_Objeto;
using System.Xml.Serialization;

namespace DAW.PRO._2.ProyectoRoguelike.Clases
{
    internal class Sala
    {
        Random rng;
        int nivel;
        int ancho;
        int alto;
        int terrenos;
        Tienda tienda;
        List<Entidad> enemigos;
        List<PNJ> pnjs;
        List<Objeto> objetos;

        Celda[,] celdas;
        public Sala(int nivel)
        {
            rng = new Random();
            for (int i = 0; i < 30; i++)
            {
                rng.Next();
            }
            this.nivel = nivel;
            ancho = 96;
            alto = 27;
            terrenos = nivel * 3;
            enemigos = new List<Entidad>();
            pnjs = new List<PNJ>();
            objetos = new List<Objeto>();
            celdas = new Celda[ancho, alto];
            generaSala(rng.Next(alto * ancho / 10, alto * ancho / 2));
            spawnEntidades((int)Math.Truncate(nivel * 1.4), (nivel + 1) % 2, (int)Math.Truncate(nivel * 1.4));
        }

        // Objetos y entidades
        void spawnEntidades(int enemigos, int pnjs, int objetos)
        {
            int rx;
            int ry;

            // Protagonista
            Partida.protagonista.spawn(ancho / 2, alto / 2);

            // Enemigos
            for (int i = 0; i < enemigos; i++)
            {
                switch (rng.Next(3))
                {
                    case 0:
                        this.enemigos[i] = new EnemigoGuerrero();
                        break;
                    case 1:
                        this.enemigos[i] = new EnemigoMago();
                        break;
                    case 2:
                        this.enemigos[i] = new EnemigoPicaro();
                        break;
                }
            }

            if (this.enemigos.Any())
            {
                for (int i = 0; i < this.enemigos.Count(); i++)
                {
                    rx = rng.Next(ancho);
                    ry = rng.Next(alto);
                    if (celdas[rx,ry] is Suelo)
                    {
                        this.enemigos[i].spawn(rx, ry);
                    }
                }
            }

            // PNJ
            // Objetos
            // Tienda
        }

        // Mapa
        public void dibujaSala()
        {
            int posX = 0;
            int posY = 0;
            for (int i = 0; i < alto; i++)
            {
                Console.SetCursorPosition(posX, posY + i);
                for (int j = 0; j < ancho; j++)
                {
                    celdas[j, i].dibuja();
                }
            }
        }
        void generaSala(int tamanio)
        {
            for (int i = 0; i < alto; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    celdas[j, i] = new Muro(j, i);
                }
            }
            tiraMuro(tamanio);
        }
        void tiraMuro(int tamanio)
        {
            int direccion;
            int tirado = 0;
            int x = ancho / 2;
            int y = alto / 2;

            do
            {
                if (x >= (ancho - 1) || y >= (alto - 1) || x <= 0 || y <= 0)
                {
                    x = ancho / 2;
                    y = alto / 2;
                }

                if (celdas[x, y] is Muro)
                {
                    celdas[x, y] = new Suelo(x, y);
                    tirado++;
                }

                direccion = rng.Next(4);

                switch (direccion)
                {
                    case 0: x++; break;
                    case 1: x--; break;
                    case 2: y++; break;
                    case 3: y--; break;
                }

            } while (tirado < tamanio);
        }
        public Celda getCelda(int x, int y)
        {
            return celdas[x, y];
        }
        public void setCelda(int x, int y, Celda nuevaCelda)
        {
            celdas[x, y] = nuevaCelda;
        }
    }
}
