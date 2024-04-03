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

        public static void DetectaTeclaPortada(int xMenu, int yMenu)
        {
            Cursor cursor = new Cursor(xMenu - 3, yMenu, 4);

            cursor.Dibuja();

            while (Partida.estado == Partida.Estado.Portada)
            {
                LimpiaBufferTecla();
                tPulsada = Console.ReadKey(true).Key;

                if (tPulsada == ConsoleKey.Enter || tPulsada == ConsoleKey.Spacebar || tPulsada == ConsoleKey.E || tPulsada == ConsoleKey.RightArrow)
                {
                    if (cursor.y == yMenu)
                    {
                        EligePersonaje(xMenu, yMenu);
                    }
                    else if (cursor.y == yMenu + 1)
                    {
                        Partida.CargaPartida();
                    }
                    else if (cursor.y == yMenu + 2)
                    {
                        Partida.Inicio();
                    }
                    else if (cursor.y == yMenu + 3)
                    {
                        Environment.Exit(0);
                    }
                }
                else if (tPulsada == tAbajo)
                {
                    cursor.Mueve(Entidad.Direccion.abajo);
                }
                else if (tPulsada == tArriba)
                {
                    cursor.Mueve(Entidad.Direccion.arriba);
                }
            }
        }
        public static int DetectaTeclaMenu(Cursor cursor)
        {
            int opcionElegida = 0;
            cursor.Dibuja();

            while (Partida.estado == Partida.Estado.Menu && opcionElegida == 0)
            {
                LimpiaBufferTecla();
                tPulsada = Console.ReadKey(true).Key;

                if (tPulsada == ConsoleKey.Enter || tPulsada == ConsoleKey.Spacebar || tPulsada == ConsoleKey.E || tPulsada == ConsoleKey.RightArrow)
                {
                    opcionElegida = cursor.Confirmar();
                }
                else if (tPulsada == tAbajo)
                {
                    cursor.Mueve(Entidad.Direccion.abajo);
                }
                else if (tPulsada == tArriba)
                {
                    cursor.Mueve(Entidad.Direccion.arriba);
                }
            }
            return opcionElegida;
        }
        static void EligePersonaje(int xMenu, int yMenu)
        {
            Cursor cursor = new Cursor(xMenu - 3, yMenu + 1, 2);
            string nombre = "";

            Console.SetCursorPosition(xMenu, yMenu);
            Console.WriteLine("              ");
            Console.SetCursorPosition(xMenu, yMenu + 1);
            Console.WriteLine("              ");
            Console.SetCursorPosition(xMenu - 3, yMenu);
            Console.WriteLine("  ");
            Console.SetCursorPosition(xMenu - 3, yMenu + 2);
            Console.WriteLine("  ");
            Console.SetCursorPosition(xMenu, yMenu + 3);
            Console.WriteLine("     ");
            Console.SetCursorPosition(xMenu, yMenu);
            Console.WriteLine("ELIGE PROFESIÓN:");
            Console.SetCursorPosition(xMenu, yMenu + 1);
            Console.WriteLine("Guerrero".PadRight(20));
            Console.SetCursorPosition(xMenu, yMenu + 2);
            Console.WriteLine("Mago".PadRight(20));

            cursor.Dibuja();

            while (Partida.estado == Partida.Estado.Portada)
            {
                LimpiaBufferTecla();
                tPulsada = Console.ReadKey(true).Key;

                if (tPulsada == ConsoleKey.Enter || tPulsada == ConsoleKey.Spacebar || tPulsada == ConsoleKey.E || tPulsada == ConsoleKey.RightArrow)
                {
                    if (cursor.y == yMenu + 1)
                    {
                        Console.SetCursorPosition(xMenu, yMenu);
                        Console.WriteLine("Introduce tu nombre:");
                        Console.SetCursorPosition(xMenu, yMenu + 1);
                        Console.WriteLine("        ");
                        Console.SetCursorPosition(xMenu, yMenu + 2);
                        Console.WriteLine("    ");
                        Console.SetCursorPosition(xMenu, yMenu + 1);
                        Console.CursorVisible = true;
                        nombre = Console.ReadLine();
                        Partida.NuevaPartida(nombre, Entidad.Profesion.Guerrero);
                    }
                    else if (cursor.y == yMenu + 2)
                    {
                        Console.SetCursorPosition(xMenu, yMenu);
                        Console.WriteLine("Introduce tu nombre:");
                        Console.SetCursorPosition(xMenu, yMenu + 1);
                        Console.WriteLine("        ");
                        Console.SetCursorPosition(xMenu, yMenu + 2);
                        Console.WriteLine("    ");
                        Console.SetCursorPosition(xMenu - 3, yMenu + 2);
                        Console.WriteLine("    ");
                        Console.SetCursorPosition(xMenu, yMenu + 1);
                        Console.CursorVisible = true;
                        nombre = Console.ReadLine();
                        Partida.NuevaPartida(nombre, Entidad.Profesion.Mago);
                    }
                }
                else if (tPulsada == tAbajo)
                {
                    cursor.Mueve(Entidad.Direccion.abajo);
                }
                else if (tPulsada == tArriba)
                {
                    cursor.Mueve(Entidad.Direccion.arriba);
                }
            }
        }
        public static void DetectaTeclaJuego()
        {
            LimpiaBufferTecla();

            tPulsada = Console.ReadKey(true).Key;

            // No se puede usar un SWITCH porque el SWITCH no acepta variables como casos.
            // El switch se comprueba de forma estática o algo de eso, el IF en cambio no (dinámico).

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
        static void AbreMenu()
        {
            Pausa pausa = new Pausa();
            pausa.DibujaMenu();

        }
        static void Habilidad() { }
        static void LimpiaBufferTecla()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
    }
}
