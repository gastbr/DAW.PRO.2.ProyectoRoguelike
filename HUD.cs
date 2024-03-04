using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike
{
    internal class HUD
    {
        string debug;
        public HUD()
        {
            debug = "(todo viento)";
        }

        public void dibuja()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(debug);
        }

        public void setDebug(string text)
        {
            debug = text;
        }
        public string getDebug()
        {
            return debug;
        }
    }

}
