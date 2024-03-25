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
            creaTerrenos((int)Math.Truncate(nivel * 2.3));
            spawnEntidades((int)Math.Truncate(nivel * 1.4), (nivel + 1) % 2, (int)Math.Truncate(nivel * 1.4));
        }

        // Objetos y entidades
        void spawnEntidades(int enemigos, int pnjs, int objetos)
        {
            int rx = rng.Next(ancho);
            int ry = rng.Next(alto);

            // Protagonista
            //if (!celdas[rx, ry].ocupada && )
            Partida.protagonista.spawn(ancho / 2, alto / 2);


            // Enemigos
            for (int i = 0; i < enemigos; i++)
            {
                switch (rng.Next(3))
                {
                    case 0:
                        this.enemigos.Add(new EnemigoGuerrero());
                        break;
                    case 1:
                        this.enemigos.Add(new EnemigoMago());
                        break;
                    case 2:
                        this.enemigos.Add(new EnemigoPicaro());
                        break;
                }
            }

            if (this.enemigos.Any())
            {
                for (int i = 0; i < this.enemigos.Count; i++)
                {
                    rx = rng.Next(ancho);
                    ry = rng.Next(alto);
                    if (celdas[rx, ry] is Suelo && !celdas[rx, ry].ocupada)
                    {
                        this.enemigos[i].spawn(rx, ry);
                    }
                }
            }

            // PNJ
            // Objetos
            // Tienda
        } // COMPLETAR

        // Terrenos
        void creaTerrenos(int terrenos)
        {
            // En celdas aleatorias, si es suelo la cambia a:
            // agua (60% prob)
            // lava (30%)
            // trampa (10%)
            // Repite tanta cantidad de veces como terrenos se pidan
            int rx;
            int ry;

            for (int i = 0; i < terrenos; i++)
            {
                rx = rng.Next(ancho);
                ry = rng.Next(alto);

                if (celdas[rx, ry] is Suelo)
                {
                    switch (rng.Next(10))
                    {
                        case 0:
                            celdas[rx, ry] = new Trampa(rx, ry);
                            break;
                        case int n when n >= 1 && n <= 3:
                            celdas[rx, ry] = new Lava(rx, ry);
                            break;
                        case int n when n > 3:
                            celdas[rx, ry] = new Agua(rx, ry);
                            break;
                    }
                }
            }
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
        Entidad compruebaEntidad(int x, int y)
        {
            Entidad hallado = null;
            for (int i = 0; i < enemigos.Count; i++)
            {
                if (celdas[x, y].ocupada)
                {

                    if (enemigos[i].x == x && enemigos[i].y == y)
                    {
                        hallado = enemigos[i];
                    }
                    else if (pnjs[i].x == x && pnjs[i].y == y)
                    {
                        hallado = pnjs[i];
                    }
                    else if (tienda.x == x && tienda.y == y)
                    {
                        hallado = tienda;
                    }
                }
            }
            return hallado;
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
