using System;

namespace ConsoleGame.GameObjects
{
    public class Blaster : FallingObject
    {
        public Blaster()
        {
            if (DodgeBlock.IsThanksgiving)
            {
                this.Character = '^';
                this.Color = ConsoleColor.Black;
                this.BackColor = ConsoleColor.Green;
            }
            else
            {
                this.Character = '^';
                this.Color = ConsoleColor.Black;
                this.BackColor = ConsoleColor.Yellow;
            }
        }
    }
}
