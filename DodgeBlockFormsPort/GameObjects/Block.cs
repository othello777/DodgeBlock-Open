using System;

namespace ConsoleGame.GameObjects
{
    public class Block : FallingObject
    {
        public Block()
        {
            this.Character = DodgeBlock.Block;
            this.Color = ConsoleColor.Black;
            this.BackColor = ConsoleColor.White;

            if (DodgeBlock.IsHolloween)
            {
                this.Character = 'I';
                this.Color = ConsoleColor.White;
                this.BackColor = ConsoleColor.Black;
            }
            else if (DodgeBlock.IsThanksgiving)
                this.BackColor = ConsoleColor.Yellow;
            else if (DodgeBlock.IsChristmas)
                this.BackColor = ConsoleColor.Cyan;
        }   
    }
}
