using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.GameObjects
{
    public class Shell : GameObject
    {
        public Shell(char Char)
        {
            this.Character = Char;
            this.Color = ConsoleColor.Black;
            this.BackColor = ConsoleColor.Cyan;
        }
    }
}
