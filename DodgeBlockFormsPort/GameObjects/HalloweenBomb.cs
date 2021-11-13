using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.GameObjects
{
    public class HalloweenBomb : FallingObject
    {
        public HalloweenBomb()
        {
            this.Character = 'G';
            this.Color = ConsoleColor.DarkMagenta;
            this.BackColor = ConsoleColor.Red;
        }
    }
}
