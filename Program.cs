using DAW.PRO._2.ProyectoRoguelike;
using DAW.PRO._2.ProyectoRoguelike.Clases;

internal class Program
{
    private static void Main(string[] args)
    {
        Partida.nuevaPartida("             IgUYUgUTuudGauGUYuGYKUYTUGTtgu        ", Entidad.Profesion.Guerrero);
        Mapa.getSala(0).DibujaSala();
        while (true)
        {
            Interfaz.dibujaHUD();
            Interfaz.dibujaEntidades();
            Controles.DetectaTecla();
        }
    }
}