using System;

namespace ConsoleGame.GameObjects
{
    public class Shot : GameObject
    {
        public Shot()
        {
            this.Character = '|';
            this.Color = ConsoleColor.Black;
            this.BackColor = ConsoleColor.Red;
        }
    }
}
