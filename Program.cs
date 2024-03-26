using DAW.PRO._2.ProyectoRoguelike;
using DAW.PRO._2.ProyectoRoguelike.Clases;

internal class Program
{
    private static void Main(string[] args)
    {
        Partida.NuevaPartida("             IgUYUgUTuudGauGUYuGYKUYTUGTtgu        ", Entidad.Profesion.Guerrero);
        Mapa.GetSala(0).DibujaSala();
        while (true)
        {
            Interfaz.DibujaHUD();
            Mapa.GetSala(0).DibujaEntidades();
            Controles.DetectaTecla();
        }
    }
}