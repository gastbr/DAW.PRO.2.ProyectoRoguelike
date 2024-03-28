namespace DAW.PRO._2.ProyectoRoguelike.Clases
{
    internal abstract class Entidad
    {
        public string nombre;
        public int id;
        public int x;
        public int y;
        public int preX;
        public int preY;
        public bool spawneado;
        public int salaActual;
        public enum Profesion { Guerrero, Mago, PNJ, Tienda };
        public Profesion profesion;
        public enum Direccion { arriba, abajo, izquierda, derecha };
        public Direccion direccion;
        public int oro;
        public int nivel;
        public int experiencia;
        public int vidaActual;
        public int vidaMax;
        public int ataque;
        public int defensa;
        public List<Objeto> inventario;
        public Objeto arma;
        public Objeto armadura;
        public string frase;
        public abstract void Dibuja();
        public void Spawn(int id, int x, int y)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            preX = x;
            preY = y;
            spawneado = true;
        }
        public void Camina(Direccion direccion)
        {
            this.direccion = direccion;
            preX = x;
            preY = y;
            int nuevaX = x;
            int nuevaY = y;
            switch (direccion)
            {
                case Direccion.arriba: nuevaY--; break;
                case Direccion.abajo: nuevaY++; break;
                case Direccion.izquierda: nuevaX--; break;
                case Direccion.derecha: nuevaX++; break;
            }

            if (Mapa.GetSala(salaActual).GetCelda(nuevaX, nuevaY).ocupada == false)
            {
                x = nuevaX;
                y = nuevaY;
                Mapa.GetSala(salaActual).GetCelda(preX, preY).ocupada = false;
                Mapa.GetSala(salaActual).GetCelda(x, y).ocupada = true;
                Mapa.GetSala(salaActual).GetCelda(x, y).entidad = this.GetType();
                Mapa.GetSala(salaActual).GetCelda(x, y).idEntidad = this.id;
            }

        }
        public virtual void Examina()
        {
        }
        public Entidad ExaminaEntidad()
        {
            Entidad hallado = null;
            switch (direccion)
            {
                case Direccion.arriba:
                    hallado = Mapa.GetSala(Partida.protagonista.salaActual).CompruebaEntidad(x, y - 1);
                    break;
                case Direccion.abajo:
                    hallado = Mapa.GetSala(Partida.protagonista.salaActual).CompruebaEntidad(x, y + 1);
                    break;
                case Direccion.derecha:
                    hallado = Mapa.GetSala(Partida.protagonista.salaActual).CompruebaEntidad(x + 1, y);
                    break;
                case Direccion.izquierda:
                    hallado = Mapa.GetSala(Partida.protagonista.salaActual).CompruebaEntidad(x - 1, y);
                    break;
            }
            return hallado;
        }
        public Objeto ExaminaObjeto()
        {
            Objeto hallado = null;
            if (Mapa.GetSala(Partida.protagonista.salaActual).CompruebaObjeto(x, y) is not null)
            {
                hallado = Mapa.GetSala(Partida.protagonista.salaActual).CompruebaObjeto(x, y);
            }
            else
            {
                switch (direccion)
                {
                    case Direccion.arriba:
                        hallado = Mapa.GetSala(Partida.protagonista.salaActual).CompruebaObjeto(x, y - 1);
                        break;
                    case Direccion.abajo:
                        hallado = Mapa.GetSala(Partida.protagonista.salaActual).CompruebaObjeto(x, y + 1);
                        break;
                    case Direccion.derecha:
                        hallado = Mapa.GetSala(Partida.protagonista.salaActual).CompruebaObjeto(x + 1, y);
                        break;
                    case Direccion.izquierda:
                        hallado = Mapa.GetSala(Partida.protagonista.salaActual).CompruebaObjeto(x - 1, y);
                        break;
                }
            }
            return hallado;
        }
        public Celda ExaminaCelda()
        {
            Celda hallado = null;
            if (Mapa.GetSala(Partida.protagonista.salaActual).GetCelda(x, y) is not SubC_Celda.Suelo)
            {
                hallado = Mapa.GetSala(Partida.protagonista.salaActual).GetCelda(x, y);
            }
            else
            {
                switch (direccion)
                {
                    case Direccion.arriba:
                        hallado = Mapa.GetSala(Partida.protagonista.salaActual).GetCelda(x, y - 1);
                        break;
                    case Direccion.abajo:
                        hallado = Mapa.GetSala(Partida.protagonista.salaActual).GetCelda(x, y + 1);
                        break;
                    case Direccion.derecha:
                        hallado = Mapa.GetSala(Partida.protagonista.salaActual).GetCelda(x + 1, y);
                        break;
                    case Direccion.izquierda:
                        hallado = Mapa.GetSala(Partida.protagonista.salaActual).GetCelda(x - 1, y);
                        break;
                }
            }
            return hallado;
        }
        public void RecibeDanio(int ataque)
        {
            vidaActual = Math.Max(0, vidaActual - Math.Max(0, ataque - defensa));
            if (vidaActual <= 0)
            {
                Muere();
            }
            for (int i = 0; i < 2; i++)
            {
                Dibuja();
                Thread.Sleep(50);
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("█");
                Thread.Sleep(50);
            }
        }
        public void RecibeCura(int cura)
        {
            if ((vidaActual + cura) >= vidaMax)
            {
                vidaActual = vidaMax;
            }
            else
            {
                vidaActual += cura;
            }

            for (int i = 0; i < 2; i++)
            {
                Dibuja();
                Thread.Sleep(50);
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("█");
                Thread.Sleep(50);
            }
        }
        public void Muere()
        {
            for (int i = 0; i < 5; i++)
            {
                Dibuja();
                Thread.Sleep(50);
                Console.SetCursorPosition(x, y);
                Console.Write("💀");
                Thread.Sleep(50);
                spawneado = false;
            }
            Console.WriteLine("Game Over");
            Thread.Sleep(200);
        }
        public virtual void Habla()
        {
            Interfaz.Escribe(nombre, frase);
        }
        public virtual void Habla(string frase)
        {
            Interfaz.Escribe(nombre, frase);
        }
    }
}
