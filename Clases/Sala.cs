using DAW.PRO._2.ProyectoRoguelike.SubC_Celda;
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
        List<Entidad> enemigos;
        Entidad pnj;
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
            objetos = new List<Objeto>();
            celdas = new Celda[ancho, alto];
            GeneraSala(rng.Next(alto * ancho / 10, alto * ancho / 2));
            CreaTerrenos((int)Math.Truncate(nivel * 2.3));
            Spawns((int)Math.Truncate(nivel * 1.4), (int)Math.Truncate(nivel * 0.5));
        }

        // Objetos y entidades
        void Spawns(int enemigos, int objetos)
        {
            int rx;
            int ry;

            // Protagonista
            while (!Partida.protagonista.spawneado)
            {
                rx = rng.Next(ancho);
                ry = rng.Next(alto);
                if (!celdas[rx, ry].ocupada && celdas[rx, ry] is Suelo)
                {
                    Partida.protagonista.Spawn(rx, ry);
                }
            }

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

            for (int i = 0; i < this.enemigos.Count; i++)
            {
                while (!this.enemigos[i].spawneado)
                {
                    rx = rng.Next(ancho);
                    ry = rng.Next(alto);
                    if (celdas[rx, ry] is Suelo && !celdas[rx, ry].ocupada)
                    {
                        this.enemigos[i].Spawn(rx, ry);
                    }
                }
            }

            // Tienda
            if (nivel - 1 % 3 == 0)
            {
                tienda = new Tienda();
                while (!tienda.spawneado)
                {
                    rx = rng.Next(ancho);
                    ry = rng.Next(alto);
                    if (celdas[rx, ry] is Suelo && !celdas[rx, ry].ocupada)
                    {
                        tienda.Spawn(rx, ry);
                    }
                }
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
            while (!pnj.spawneado)
            {
                rx = rng.Next(ancho);
                ry = rng.Next(alto);
                if (celdas[rx, ry] is Suelo && !celdas[rx, ry].ocupada)
                {
                    pnj.Spawn(rx, ry);
                }
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
                    else if (Partida.protagonista is JugadorPicaro)
                    {
                        this.objetos.Add(new Daga());
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
                    else if (Partida.protagonista is JugadorPicaro)
                    {
                        this.objetos.Add(new Capa());
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

            for (int i = 0; i < this.objetos.Count; i++)
            {
                while (!this.objetos[i].spawneado)
                {
                    rx = rng.Next(ancho);
                    ry = rng.Next(alto);
                    if (celdas[rx, ry] is Suelo && !celdas[rx, ry].ocupada)
                    {
                        this.objetos[i].Spawn(rx, ry);
                    }
                }
            }
        }

        // Terrenos
        void CreaTerrenos(int terrenos)
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
            } while (!(celdas[rx, ry] is Entrada));

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
            celdas[x, y] = new Salida(x, y);
        }
        Entidad CompruebaEntidad(int x, int y)
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
                    else if (pnj.x == x && pnj.y == y)
                    {
                        hallado = pnj;
                    }
                    else if (tienda.x == x && tienda.y == y)
                    {
                        hallado = tienda;
                    }
                }
            }
            return hallado;
        }
        public Celda GetCelda(int x, int y)
        {
            return celdas[x, y];
        }
        public void SetCelda(int x, int y, Celda nuevaCelda)
        {
            celdas[x, y] = nuevaCelda;
        }
    }
}
