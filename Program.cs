using DAW.PRO._2.ProyectoRoguelike;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Mapa CasaPepe = new Mapa(95,30);
        HUD hud = new HUD();
        while (true)
        {
            CasaPepe.dibuja();
            hud.dibuja();
            hud.setDebug();
            Console.ReadLine();
        }
    }
}