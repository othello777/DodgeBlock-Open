using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.GameObjects
{
    public class BackDrop : GameObject
    {
        public BackDrop()
        {
            if (DodgeBlock.IsHolloween)
            {
                this.Character = DodgeBlock.Backdrop;
                this.Color = ConsoleColor.DarkGreen;
            }
            else if (DodgeBlock.IsThanksgiving)
            {
                this.Character = DodgeBlock.Backdrop;
                this.Color = ConsoleColor.DarkGray;
            }
            else if (DodgeBlock.IsChristmas)
            {
                this.Character = DodgeBlock.Backdrop;
                this.Color = ConsoleColor.White;
            }
            else
            {
                this.Character = DodgeBlock.Backdrop;
                this.Color = ConsoleColor.Blue;
            }
        }
        public BackDrop(ConsoleColor Backcolor)
        {
            this.BackColor = Backcolor;
        }
    }
}
