﻿using DAW.PRO._2.ProyectoRoguelike.SubC_Celda;
using DAW.PRO._2.ProyectoRoguelike.SubC_Entidad;
using DAW.PRO._2.ProyectoRoguelike.SubC_Objeto;
using System.Numerics;
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
        Entidad pnj;
        List<Entidad> enemigos;
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
            tienda = new Tienda();
            pnj = new PNJ();
            terrenos = nivel * 3;
            enemigos = new List<Entidad>();
            objetos = new List<Objeto>();
            celdas = new Celda[ancho, alto];
            GeneraSala(rng.Next(alto * ancho / 10, alto * ancho / 2));
            CreaTerrenos((int)Math.Truncate(nivel * 2.3));
            GeneraEntidades((int)Math.Truncate(nivel * 1.4), (int)Math.Truncate(nivel * 0.5));
            SpawnEntidades();
        }

        // Objetos y entidades
        void GeneraEntidades(int enemigos, int objetos)
        {
            int rx;
            int ry;

            // Enemigos
            for (int i = 0; i < enemigos; i++)
            {
                switch (rng.Next(2))
                {
                    case 0:
                        this.enemigos.Add(new EnemigoGuerrero());
                        break;
                    case 1:
                        this.enemigos.Add(new EnemigoMago());
                        break;
                }
            }

            // Tienda

            if (nivel - 1 % 3 == 0)
            {
                tienda = new Tienda();
            }

            // PNJ
            if (nivel == 0)
            {
                pnj = new Mision();
            }
            else if (nivel % 2 == 0)
            {
                pnj = new PNJ();
            }

            // Objetos
            int objetosCreados = 0;

            while (objetosCreados < objetos)
            {
                rx = rng.Next(100);

                if (!Mapa.dropMono && rx <= (1.5 * nivel))
                {
                    this.objetos.Add(new MonoDeJade());
                    objetosCreados++;
                }

                if (!Mapa.dropAtaque && rx > (0.7 * nivel) && rx <= (8.7 * nivel))
                // esto significa que el droprate es de 8 (si el dado saca entre 0.7 y 8.7
                // empieza en 0.7 para que la probabilidad se solape en un 50% con la del Mono
                // Esto tiene sentido porque en cada vuelta del bucle pueden generarse varios objetos, haciendo que la cantidad de objetos no sea estática según el nivel
                {
                    if (Partida.protagonista is JugadorGuerrero)
                    {
                        this.objetos.Add(new Espada());
                        objetosCreados++;
                    }
                    else if (Partida.protagonista is JugadorMago)
                    {
                        this.objetos.Add(new Baston());
                        objetosCreados++;
                    }
                }

                if (!Mapa.dropDefensa && rx > (6 * nivel) && rx <= (16 * nivel))
                // droprate 10
                // se solapa con el ataque
                {
                    if (Partida.protagonista is JugadorGuerrero)
                    {
                        this.objetos.Add(new Escudo());
                        objetosCreados++;
                    }
                    else if (Partida.protagonista is JugadorMago)
                    {
                        this.objetos.Add(new Anillo());
                        objetosCreados++;
                    }
                }

                if (rx >= (25 - nivel * 2) && rx <= (75 + nivel * 2))
                // droprate de curas: 50% mínimo, aumenta en un 4% por nivel
                // Si cae cura, la probabilidad de que sea Pan disminuye con el nivel y la de la poción aumenta.
                // Si no es ni cura ni pan, es manzana, cuyo D-R aumenta hasta el nivel 12, y luego empieza a caer para dar paso a la poción.
                {
                    switch (rng.Next(100))
                    {
                        case int n when n < 70 - (nivel * 5):
                            this.objetos.Add(new Pan());
                            objetosCreados++;
                            break;
                        case int n when n >= 99 - (nivel * 4) && n < 100:
                            this.objetos.Add(new Pocion());
                            objetosCreados++;
                            break;
                        default:
                            this.objetos.Add(new Manzana());
                            objetosCreados++;
                            break;
                    }
                }
            }
        }
        public void SpawnEntidades()
        {
            int rx;
            int ry;

            // Protagonista

            while (!Partida.protagonista.spawneado)
            {
                Partida.protagonista.Spawn(-1, BuscaEntrada().x, BuscaEntrada().y);
                celdas[BuscaEntrada().x, BuscaEntrada().y].ocupada = true;

            }

            // Enemigos

            for (int i = 0; i < this.enemigos.Count; i++)
            {
                while (!this.enemigos[i].spawneado)
                {
                    rx = rng.Next(ancho);
                    ry = rng.Next(alto);
                    if (celdas[rx, ry] is Suelo && !celdas[rx, ry].ocupada)
                    {
                        this.enemigos[i].Spawn(i, rx, ry);
                        celdas[rx, ry].ocupada = true;
                        celdas[rx, ry].idEntidad = i;
                        celdas[rx, ry].entidad = this.enemigos[i].GetType();
                    }
                }
            }

            // Tienda
            if (nivel - 1 % 3 == 0)
            {
                while (!tienda.spawneado)
                {
                    rx = rng.Next(ancho);
                    ry = rng.Next(alto);
                    if (celdas[rx, ry] is Suelo && !celdas[rx, ry].ocupada && CeldaAislada(rx, ry))
                    {
                        tienda.Spawn(-1, rx, ry);
                        celdas[rx, ry].ocupada = true;
                        celdas[rx, ry].idEntidad = -1;
                        celdas[rx, ry].entidad = tienda.GetType();
                    }
                }
            }

            // PNJ
            if (nivel % 2 == 0)
            {
                while (!pnj.spawneado)
                {
                    rx = rng.Next(ancho);
                    ry = rng.Next(alto);
                    if (celdas[rx, ry] is Suelo && !celdas[rx, ry].ocupada && CeldaAislada(rx, ry))
                    {
                        pnj.Spawn(-1, rx, ry);
                        celdas[rx, ry].ocupada = true;
                        celdas[rx, ry].idEntidad = -1;
                        celdas[rx, ry].entidad = pnj.GetType();
                    }
                }
            }

            // Objetos

            for (int i = 0; i < this.objetos.Count; i++)
            {
                while (!this.objetos[i].spawneado)
                {
                    rx = rng.Next(ancho);
                    ry = rng.Next(alto);
                    if (celdas[rx, ry] is Suelo && !celdas[rx, ry].ocupada)
                    {
                        this.objetos[i].Spawn(i, rx, ry);
                        celdas[rx, ry].idObjeto = i;
                        celdas[rx, ry].objeto = this.objetos[i].GetType();
                    }
                }
            }
        }
        public void DibujaEntidades()
        {
            if (pnj.spawneado)
            {
                GetPNJ().Dibuja();
            }

            if (tienda.spawneado)
            {
                tienda.Dibuja();
            }

            for (int i = 0; i < enemigos.Count; i++)
            {
                DibujaEntidadMovil(enemigos[i]);
            }

            for (int i = 0; i < objetos.Count; i++)
            {
                objetos[i].Dibuja();
            }

            if (Partida.protagonista.spawneado)
            {
                DibujaEntidadMovil(Partida.protagonista);
            }
        }
        void DibujaEntidadMovil(Entidad personaje)
        {
            // Si hay un objeto en la celda abandonada, lo dibuja, de lo contrario dibuja la celda
            // A continuación, dibuja el personaje en su posición actual
            if (celdas[personaje.preX, personaje.preY].idObjeto >= 0)
            {
                objetos[celdas[personaje.preX, personaje.preY].idObjeto.Value].Dibuja();
            }
            else
            {
                celdas[personaje.preX, personaje.preY].Dibuja();
            }

            personaje.Dibuja();
        }
        public Entidad CompruebaEntidad(int x, int y)
        {
            Entidad hallado = null;
            // El for empieza en -2 para que cuente la tienda y el pnj, que siempre están construidos

            if (celdas[x, y].ocupada)
            {
                if (tienda.x == x && tienda.y == y)
                {
                    hallado = tienda;
                }
                else if (pnj.x == x && pnj.y == y)
                {
                    hallado = pnj;
                }
                else if (enemigos.Count > 0)
                {
                    for (int i = 0; i < enemigos.Count; i++)
                    {
                        if (enemigos[i].x == x && enemigos[i].y == y)
                        {
                            hallado = enemigos[i];
                        }
                    }
                }
            }
            return hallado;
        }
        public Objeto CompruebaObjeto(int x, int y)
        {
            Objeto hallado = null;
            for (int i = 0; i < objetos.Count; i++)
            {
                if (objetos[i].x == x && objetos[i].y == y)
                {
                    hallado = objetos[i];
                }
            }
            return hallado;
        }

        // Terrenos
        private bool CeldaAislada(int x, int y)
        {
            // Si todas las celdas que rodean a la que entra por parámetros son suelo, devuelve TRUE
            // Si alguna NO es suelo, devuelve false
            // También comprueba si están todas sin ocupar

            return
                (
                celdas[x - 1, y - 1] is Suelo &&
                celdas[x - 1, y] is Suelo &&
                celdas[x - 1, y + 1] is Suelo &&
                celdas[x, y - 1] is Suelo &&
                celdas[x, y + 1] is Suelo &&
                celdas[x + 1, y - 1] is Suelo &&
                celdas[x + 1, y] is Suelo &&
                celdas[x + 1, y + 1] is Suelo &&

                !celdas[x - 1, y - 1].ocupada &&
                !celdas[x - 1, y].ocupada &&
                !celdas[x - 1, y + 1].ocupada &&
                !celdas[x, y - 1].ocupada &&
                !celdas[x, y + 1].ocupada &&
                !celdas[x + 1, y - 1].ocupada &&
                !celdas[x + 1, y].ocupada &&
                !celdas[x + 1, y + 1].ocupada
                );
        }
        private void CreaTerrenos(int terrenos)
        {
            // Primero genera una entrada
            // En celdas aleatorias, si es suelo la cambia a:
            // agua (60% prob)
            // lava (30%)
            // trampa (10%)
            // Repite tanta cantidad de veces como terrenos se pidan
            int rx;
            int ry;

            do
            {
                rx = rng.Next(ancho);
                ry = rng.Next(alto);
                if (celdas[rx, ry] is Suelo)
                {
                    celdas[rx, ry] = new Entrada(rx, ry);
                }
            } while (celdas[rx, ry] is not Entrada);

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
        public Entrada BuscaEntrada()
        {
            Entrada? hallado = null;
            for (int i = 0; i < ancho; i++)
            {
                for (int j = 0; j < alto; j++)
                {
                    if (celdas[i, j] is Entrada)
                    {
                        hallado = (Entrada)celdas[i, j];
                    }
                }
            }
            return hallado;
        }
        public Salida BuscaSalida()
        {
            Salida? hallado = null;
            for (int i = 0; i < ancho; i++)
            {
                for (int j = 0; j < alto; j++)
                {
                    if (celdas[i, j] is Salida)
                    {
                        hallado = (Salida)celdas[i, j];
                    }
                }
            }
            return hallado;
        }
        public void DibujaSala()
        {
            int posX = 0;
            int posY = 0;
            for (int i = 0; i < alto; i++)
            {
                Console.SetCursorPosition(posX, posY + i);
                for (int j = 0; j < ancho; j++)
                {
                    celdas[j, i].Dibuja();
                }
            }
        }
        void GeneraSala(int tamanio)
        {
            for (int i = 0; i < alto; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    celdas[j, i] = new Muro(j, i);
                }
            }
            RandomWalker(tamanio);
        }
        void RandomWalker(int tamanio)
        {
            int direccion;
            int tirado = 0;
            int x = ancho / 2;
            int y = alto / 2;

            do
            {
                if (x >= (ancho - 2) || y >= (alto - 2) || x <= 1 || y <= 1)
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
            celdas[x, y] = new Salida(x, y);
        }

        // Getters
        public Celda GetCelda(int x, int y)
        {
            return celdas[x, y];
        }
        public Tienda GetTienda()
        {
            return tienda;
        }
        public Entidad GetPNJ()
        {
            return pnj;
        }
        public List<Entidad> GetEnemigos()
        {
            return enemigos;
        }
        public List<Objeto> GetObjetos()
        {
            return objetos;
        }
    }
}
