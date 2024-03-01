using DAW.PRO._2.ProyectoRoguelike;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Mapa CasaPepe = new Mapa(95,30);
        while (true)
        {
            CasaPepe.dibuja();
            Console.ReadLine();
        }
    }


}