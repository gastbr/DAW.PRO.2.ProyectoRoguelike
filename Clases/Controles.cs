using DAW.PRO._2.ProyectoRoguelike.SubC_Entidad;

namespace DAW.PRO._2.ProyectoRoguelike.Clases
{
    internal static class Controles
    {
        static ConsoleKey tPulsada;
        static ConsoleKey tArriba = ConsoleKey.UpArrow;
        static ConsoleKey tAbajo = ConsoleKey.DownArrow;
        static ConsoleKey tDerecha = ConsoleKey.RightArrow;
        static ConsoleKey tIzquierda = ConsoleKey.LeftArrow;
        static ConsoleKey tExaminar = ConsoleKey.E;
        static ConsoleKey tAtaque = ConsoleKey.Spacebar;
        static ConsoleKey tHabilidad = ConsoleKey.C;
        static ConsoleKey tInventario = ConsoleKey.Q;
        static ConsoleKey tMenu = ConsoleKey.Escape;

        public static void DetectaTecla()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            tPulsada = Console.ReadKey(true).Key;

            if (tPulsada == tExaminar)
            {
                Examina();
            }
            else if (tPulsada == tAtaque)
            {
                Ataca();
            }
            else if (tPulsada == tHabilidad)
            {
                Habilidad();
            }
            else if (tPulsada == tInventario)
            {
                AbreInventario();
            }
            else if (tPulsada == tMenu)
            {
                AbreMenu();
            }
            else if (tPulsada == ConsoleKey.M)
            {
                Partida.protagonista.Muere();
            }
            else if (tPulsada == ConsoleKey.N)
            {
                Partida.protagonista.RecibeCura(2);
            }
            else if (tPulsada == ConsoleKey.B)
            {
                Partida.protagonista.RecibeDanio(2);
            }
            else if (tPulsada == ConsoleKey.V)
            {
                Partida.NuevaPartida("prrrrro", Entidad.Profesion.Mago);
                Mapa.GetSala(0).DibujaSala();
            }

            Mueve(tPulsada);
        }
        static void Mueve(ConsoleKey tecla)
        {
            // No se puede usar un SWITCH porque el SWITCH no acepta variables como casos.
            // El switch se comprueba de forma estática o algo de eso, el IF en cambio no (dinámico).

            if (tecla == tArriba || tecla == ConsoleKey.W)
            {
                Partida.protagonista.Camina(Entidad.Direccion.arriba);
            }
            else if (tecla == tAbajo || tecla == ConsoleKey.S)
            {
                Partida.protagonista.Camina(Entidad.Direccion.abajo);
            }
            else if (tecla == tDerecha || tecla == ConsoleKey.D)
            {
                Partida.protagonista.Camina(Entidad.Direccion.derecha);
            }
            else if (tecla == tIzquierda || tecla == ConsoleKey.A)
            {
                Partida.protagonista.Camina(Entidad.Direccion.izquierda);
            }
        }
        static void Examina()
        {
            Partida.protagonista.Examina();
        }
        static void Ataca()
        {
        }
        static void AbreInventario() { }
        static void AbreMenu() { }
        static void Habilidad() { }
    }
}
