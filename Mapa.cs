namespace DAW.PRO._2.ProyectoRoguelike
{
    internal class Mapa
    {
        int ancho;
        int alto;
        Celda[,] celdas;
        public Mapa(int ancho, int alto)
        {
            this.ancho = ancho;
            this.alto = alto;
            celdas = new Celda[ancho, alto];
            for (int i = 0; i < alto; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    celdas[j, i] = new Celda();
                }
            }
            randomWalker(30);
        }

        public void dibuja()
        {
            Console.Clear();
            for (int i = 0; i < alto; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < ancho; j++)
                {
                    // El +25 en la J hace que el mapa se empiece a dibujar 25 caracteres a la derecha, dejando espacio para la interfaz
                    Console.SetCursorPosition(j + 25, i);
                    celdas[j, i].dibuja();
                }
            }

        }
        public bool creaSuelo(int x, int y)
        {
            if (celdas[x, y].getTerreno() == Terreno.Muro)
            {
                celdas[x, y].setTerreno(Terreno.Suelo);
                return true;
            }
            return false;
        }
        public bool creaLava(int x, int y)
        {
            if (celdas[x, y].getTerreno() == Terreno.Muro)
            {
                celdas[x, y].setTerreno(Terreno.Lava);
                return true;
            }
            return false;
        }
        public bool creaAgua(int x, int y)
        {
            if (celdas[x, y].getTerreno() == Terreno.Muro)
            {
                celdas[x, y].setTerreno(Terreno.Agua);
                return true;
            }
            return false;
        }
        public void randomWalker(int porcentajeSuelo)
        {
            // La función recibe como parámetro el porcentaje de suelo que se busca, basado en el ancho y alto del mapa Con ese porcentaje, se calcula la cantidad de baldosas de suelo que se crearán (cantidadSuelo). De esta forma, no hace falta tener en cuenta el ancho y alto del mapa para establecer la cantidad de suelo que queremos.
            // caminado es un contador que controla la cantidad de suelo construido (el bucle se repetirá hasta que sea igual que cantidadSuelo).
            // x, y indican la posición actual del RW.

            Random rng = new Random();
            rng.Next(30); // se descartan los primeros 30 números aleatorios del objeto Random
            int cantidadSuelo = (ancho * alto) * (porcentajeSuelo / 100);
            int x = ancho / 2;
            int y = alto / 2;
            int caminado = 0;
            int direccion = 0;

            do
            {
                if (x >= ancho || y >= alto || x <= 1 || y <= 1)
                {
                    x = ancho / 2;
                    y = alto / 2;
                }
                bool ok = creaSuelo(x, y);
                if (ok)
                {
                    caminado++;
                }
                direccion = rng.Next(4);
                switch (direccion)
                {
                    case 0:
                        x++;
                        break;
                    case 1:
                        y++;
                        break;
                    case 2:
                        x--;
                        break;
                    case 3:
                        y--;
                        break;
                }
            }
            while (caminado < cantidadSuelo);


        }
    }
}
