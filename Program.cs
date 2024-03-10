using DAW.PRO._2.ProyectoRoguelike;
using DAW.PRO._2.ProyectoRoguelike.Clases;

internal class Program
{
    private static void Main(string[] args)
    {
        Partida.nuevaPartida("   elver  ", Entidad.Profesion.Guerrero);
        while (true)
        {
            HUD.dibuja();
            Mapa.getSala(0).dibuja();
        }
    }
}