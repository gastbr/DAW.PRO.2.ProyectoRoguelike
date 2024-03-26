namespace DAW.PRO._2.ProyectoRoguelike.Clases
{
    internal abstract class Entidad
    {
        public string nombre;
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
        public abstract void Dibuja();
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
            }

        }
        public void Explora()
        {

            switch (direccion)
            {
                case Direccion.arriba:
                    Mapa.GetSala(salaActual).CompruebaEntidad(x, y - 1);
                    break;
                case Direccion.abajo:
                    Mapa.GetSala(salaActual).CompruebaEntidad(x, y + 1);
                    break;
                case Direccion.izquierda:
                    Mapa.GetSala(salaActual).CompruebaEntidad(x - 1, y);
                    break;
                case Direccion.derecha:
                    Mapa.GetSala(salaActual).CompruebaEntidad(x + 1, y);
                    break;
            }
        }
        public void Spawn(int x, int y)
        {
            this.x = x;
            this.y = y;
            preX = x;
            preY = y;
            spawneado = true;
        }
    }
}
