using System;
using System.Collections.Generic;

namespace ConsoleGame.GameObjects
{
    public class BonusPoints : FallingObject
    {
        public BonusPoints()
        {
            if (DodgeBlock.IsHolloween)
            {
                this.Character = '@';
                this.Color = ConsoleColor.Blue;
                this.BackColor = ConsoleColor.Magenta;
            }
            else if (DodgeBlock.IsThanksgiving)
            {
                this.Character = DodgeBlock.BonusPoint;
                this.Color = ConsoleColor.Black;
                this.BackColor = ConsoleColor.Red;
            }
            else if (DodgeBlock.IsChristmas)
            {
                List<ConsoleColor> ColorList = new List<ConsoleColor>()
                {
                    ConsoleColor.White,
                    ConsoleColor.Magenta,
                    ConsoleColor.Green,
                    ConsoleColor.Yellow,
                    ConsoleColor.Red,
                    ConsoleColor.Blue,
                    ConsoleColor.Cyan,
                };

                this.Character = DodgeBlock.BonusPoint;
                this.Color = ConsoleColor.Black;
                this.BackColor = ColorList[DodgeBlock.random2.Next(0, ColorList.Count - 1)];
            }
            else
            {
                this.Character = DodgeBlock.BonusPoint;
                this.Color = ConsoleColor.Black;
                this.BackColor = ConsoleColor.Magenta;
            }
        }
    }
}
