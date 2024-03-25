namespace DAW.PRO._2.ProyectoRoguelike.Clases
{
    internal static class Controles
    {
        static ConsoleKey tecla;
        static public void DetectaTecla()
        {
            tecla = Console.ReadKey(true).Key;
            Mueve(tecla);
            Interactua(tecla);
        }
        static void Mueve(ConsoleKey tecla)
        {
            switch (tecla)
            {
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    Partida.protagonista.camina(Entidad.Direccion.abajo);
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    Partida.protagonista.camina(Entidad.Direccion.arriba);
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    Partida.protagonista.camina(Entidad.Direccion.izquierda);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    Partida.protagonista.camina(Entidad.Direccion.derecha);
                    break;
            }
        }
        static void Interactua(ConsoleKey tecla)
        {

        }
        static void AbreInventario() { }
        static void AbandonaPartida() { }
    }
}
