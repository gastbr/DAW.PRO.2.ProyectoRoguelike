﻿using DAW.PRO._2.ProyectoRoguelike.SubC_Celda;
using DAW.PRO._2.ProyectoRoguelike.SubC_Entidad;
using DAW.PRO._2.ProyectoRoguelike.SubC_Objeto;

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
            rng.Next(30);
            this.nivel = nivel;
            // El ancho y alto del mapa son fijos, para ajustarse a la pantalla.
            ancho = 96;
            alto = 27;
            celdas = new Celda[ancho, alto];
            // El tamaño (suelo) de la sala es aleatorio y varía según el tamaño de la sala incluyendo los muros (alto*ancho).
            generaSala(rng.Next(alto * ancho / 10, alto * ancho / 2));
            // La cantidad de enemigos y de objetos aumenta proporcionalmente con el nivel según el ratio (ajustable) que se especifica por parámetros:
            terrenos = nivel * 4;
            spawnEntidades(nivel * 1, nivel * 1, terrenos);
            spawnEntidades();
        }
        public void spawnEntidades( )
        {
            int rx;
            int ry;

            Partida.protagonista.spawn(ancho / 2, alto / 2);

            // Spawn Tienda
            do
            {
                rx = rng.Next(ancho);
                ry = rng.Next(alto);
                if (celdas[rx, ry] is Suelo && celdas[rx, ry].ocupada == false)
                {
                    tienda.spawn(rx, ry);
                }
            } while (!(celdas[rx, ry] is Suelo && celdas[rx, ry].ocupada == false));
            celdas[rx, ry].ocupada = true;

            //// Spawn Enemigos
            //if (enemigos.Any())
            //{
            //    for (int i = 0; i < enemigos.Count; i++)
            //    {
            //        do
            //        {
            //            rx = rng.Next(ancho);
            //            ry = rng.Next(alto);
            //            if (celdas[rx, ry] is Suelo && celdas[rx, ry].ocupada == false)
            //            {
            //                enemigos[i].spawn(rx, ry);
            //            }
            //        } while (!(celdas[rx, ry] is Suelo && celdas[rx, ry].ocupada == false));
            //        celdas[rx, ry].ocupada = true;
            //    }
            //}
            //// pendiente spawn pnj y objetos
        } 
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
                    celdas[j, i] = new Muro(j,i);
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
        void spawnEntidades(int cantEnemigos, int cantObjetos, int cantTerrenos)
        {
            // La tienda solo aparece una vez cada tres niveles
            if (nivel % 3 == 0)
            {
                tienda = new Tienda();
            }
            for (int i = 0; i < cantEnemigos; i++)
            {
                int r = rng.Next(3);
                switch (r)
                {
                    case 0: this.enemigos.Add(new EnemigoGuerrero()); break;
                    case 1: this.enemigos.Add(new EnemigoMago()); break;
                    case 2: this.enemigos.Add(new EnemigoPicaro()); break;
                }
            }
            for (int i = 0; i < cantObjetos; i++)
            {
                barajaObjetos(cantObjetos);
            }
            for (int i = 0; i < cantTerrenos; i++)
            {
                barajaTerrenos(cantTerrenos);
            }
        }
        void barajaObjetos(int objetos)
        {
            while (this.objetos.Count < objetos)
            {
                int r1 = rng.Next(100);
                int r2 = rng.Next(100);
                switch (r1)
                {
                    case int i when i >= 0 && i < 7: // 7% droprate
                        if (r2 < (7 * nivel))
                        {
                            this.objetos.Add(new SantoGrial());
                        }
                        break;
                    case int i when i >= 7 && i < 22: // 22-7 = 15% droprate
                        if (r2 < (15 * nivel))
                        {
                            this.objetos.Add(new Pocion());
                        }
                        break;
                    case int i when i >= 22 && i < 52: // 52-22 = 30% droprate
                        if (r2 < (30 * nivel))
                        {
                            this.objetos.Add(new Manzana());
                        }
                        break;
                    case int i when i >= 52 && i < 100: // 100-52 = 48% droprate
                        if (r2 < (48 * nivel))
                        {
                            this.objetos.Add(new Pan());
                        }
                        break;
                }
            }
        }
        void barajaTerrenos(int terrenos)
        {
            int r1 = rng.Next(100);
            int r2 = rng.Next(100);
            while (this.terrenos < terrenos)
            {
                for (int i = 0; i < ancho; i++)
                {
                    for (int j = 0; j < alto; j++)
                    {
                        if (celdas[j, i] is Suelo)
                        {
                            switch (r1)
                            {
                                case int k when k >= 0 && k < 15:
                                    if (r2 <= (30 * nivel))
                                    {
                                        celdas[j, i] = new Lava(j, i);
                                        this.terrenos++;
                                    }
                                    break;
                                case int k when k >= 15 && k < 50:
                                    if (r2 <= (70 * nivel))
                                    {
                                        celdas[j, i] = new Agua(j, i);
                                        this.terrenos++;
                                    }
                                    break;
                                case int k when k >= 50 && k < 55:
                                    if (r2 <= (30 * nivel))
                                    {
                                        celdas[j, i] = new Trampa(j, i);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
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
