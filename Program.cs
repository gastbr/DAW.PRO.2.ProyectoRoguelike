using DAW.PRO._2.ProyectoRoguelike;
using DAW.PRO._2.ProyectoRoguelike.Clases;

internal class Program
{
    private static void Main(string[] args)
    {
        Partida.nuevaPartida("        wqerasdfqweras      ", Entidad.Profesion.Guerrero);
        while (true)
        {
            Mapa.getSala(0).dibujaSala();
            Interfaz.dibujaHUD();
            Partida.protagonista.dibuja(); // Interfaz.dibujaEntidades();            
            Controles.detectaTecla();
        }
    }
}