using System;

namespace ConsoleGame.GameObjects
{
    public class Shield : FallingObject
    {
        public Shield()
        {
            this.Character = '~';
            this.Color = ConsoleColor.Black;
            this.BackColor = ConsoleColor.Cyan;
        }
    }
}
