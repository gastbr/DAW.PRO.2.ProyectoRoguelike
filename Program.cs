using DAW.PRO._2.ProyectoRoguelike;
using DAW.PRO._2.ProyectoRoguelike.Clases;

internal class Program
{
    private static void Main(string[] args)
    {
        Partida.nuevaPartida("             IgUYUgUTuudGauGUYuGYKUYTUGTtgu        ", Entidad.Profesion.Guerrero);
        Mapa.getSala(0).dibujaSala();
        while (true)
        {
            Interfaz.dibujaHUD();
            Interfaz.dibujaEntidades();            
            Controles.detectaTecla();
        }
    }
}