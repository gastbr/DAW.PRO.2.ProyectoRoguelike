using DAW.PRO._2.ProyectoRoguelike;
using DAW.PRO._2.ProyectoRoguelike.Clases;

internal class Program
{
    private static void Main(string[] args)
    {
        Partida.nuevaPartida("    SAIDUHYAhbashbkauUAYGDU  ", Entidad.Profesion.Guerrero);
        while (true)
        {
            Mapa.getSala(0).dibujaSala();
            Interfaz.dibujaHUD();
            Interfaz.dibujaInfoAbajo();
            Interfaz.dibujaInfoArriba();
            Interfaz.dibujaEntidades();
        }
    }
}