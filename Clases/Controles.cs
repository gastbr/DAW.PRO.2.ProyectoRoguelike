using DAW.PRO._2.ProyectoRoguelike.SubC_Entidad;

namespace DAW.PRO._2.ProyectoRoguelike.Clases
{
    internal static class Controles
    {
        static ConsoleKey TPulsada;
        static ConsoleKey TArriba = ConsoleKey.UpArrow;
        static ConsoleKey TAbajo = ConsoleKey.DownArrow;
        static ConsoleKey TDerecha = ConsoleKey.RightArrow;
        static ConsoleKey TIzquierda = ConsoleKey.LeftArrow;
        static ConsoleKey TExaminar = ConsoleKey.C;
        static ConsoleKey TAtaque = ConsoleKey.Spacebar;
        static ConsoleKey THabilidad = ConsoleKey.X;
        static ConsoleKey TInventario = ConsoleKey.Z;
        static ConsoleKey TMenu = ConsoleKey.Escape;

        public static void DetectaTecla()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            TPulsada = Console.ReadKey(true).Key;

            if (TPulsada == TExaminar)
            {
                Examina();
            }
            else if (TPulsada == TAtaque)
            {
                Ataca();
            }
            else if (TPulsada == THabilidad)
            {
                Habilidad();
            }
            else if (TPulsada == TInventario)
            {
                AbreInventario();
            }
            else if (TPulsada == TMenu)
            {
                AbreMenu();
            }
            else if (TPulsada == ConsoleKey.M)
            {
                Partida.protagonista.Muere();
            }
            else if (TPulsada == ConsoleKey.N)
            {
                Partida.protagonista.RecibeCura(2);
            }
            else if (TPulsada == ConsoleKey.B)
            {
                Partida.protagonista.RecibeDanio(2);
            }
            else if (TPulsada == ConsoleKey.V)
            {
                Partida.NuevaPartida("prrrrro", Entidad.Profesion.Mago);
                Mapa.GetSala(0).DibujaSala();
            }

            Mueve(TPulsada);
        }
        static void Mueve(ConsoleKey tecla)
        {
            // No se puede usar un SWITCH porque el SWITCH no acepta variables como casos.
            // El switch se comprueba de forma estática o algo de eso, el IF no (dinámico).

            if (tecla == TArriba)
            {
                Partida.protagonista.Camina(Entidad.Direccion.arriba);
            }
            else if (tecla == TAbajo)
            {
                Partida.protagonista.Camina(Entidad.Direccion.abajo);
            }
            else if (tecla == TDerecha)
            {
                Partida.protagonista.Camina(Entidad.Direccion.derecha);
            }
            else if (tecla == TIzquierda)
            {
                Partida.protagonista.Camina(Entidad.Direccion.izquierda);
            }
        }
        static void Examina()
        {

        }
        static void Ataca()
        {
        }
        static void AbreInventario() { }
        static void AbreMenu() { }
        static void Habilidad() { }
    }
}
