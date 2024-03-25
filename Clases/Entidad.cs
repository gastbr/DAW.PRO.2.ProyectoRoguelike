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
        public enum Profesion { Guerrero, Mago, Picaro, PNJ, Tienda };
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
        public void camina(Direccion direccion)
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
            if (Mapa.getSala(salaActual).GetCelda(nuevaX, nuevaY).ocupada == false)
            {
                x = nuevaX;
                y = nuevaY;
                Mapa.getSala(salaActual).GetCelda(preX, preY).ocupada = false;
                Mapa.getSala(salaActual).GetCelda(x, y).ocupada = true;
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
