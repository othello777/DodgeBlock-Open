using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.GameObjects
{
    public class Player : GameObject
    {
        public Player(int PlayerNo)
        {
            if (DodgeBlock.IsHolloween)
            {
                if (PlayerNo == 1)
                {
                    this.Character = DodgeBlock.Avatar;
                    this.Color = ConsoleColor.DarkMagenta;

                }
                else if (PlayerNo == 2)
                {
                    this.Character = DodgeBlock.Avatar2;
                    this.Color = ConsoleColor.Yellow;

                }
                else
                {
                    this.Character = '@';
                    this.Color = ConsoleColor.Red;

                }
            }
            else if (DodgeBlock.IsThanksgiving)
            {
                if (PlayerNo == 1)
                {
                    this.Character = DodgeBlock.Avatar;
                    this.Color = ConsoleColor.DarkMagenta;

                }
                else if (PlayerNo == 2)
                {
                    this.Character = DodgeBlock.Avatar2;
                    this.Color = ConsoleColor.Red;

                }
                else
                {
                    this.Character = '@';
                    this.Color = ConsoleColor.Yellow;

                }
            }
            else if (DodgeBlock.IsChristmas)
            {
                if (PlayerNo == 1)
                {
                    this.Character = DodgeBlock.Avatar;
                    this.Color = ConsoleColor.Red;

                }
                else if (PlayerNo == 2)
                {
                    this.Character = DodgeBlock.Avatar2;
                    this.Color = ConsoleColor.Green;

                }
                else
                {
                    this.Character = '@';
                    this.Color = ConsoleColor.Yellow;

                }
            }
            else
            {
                if (PlayerNo == 1)
                {
                    this.Character = DodgeBlock.Avatar;
                    this.Color = ConsoleColor.Cyan;

                }
                else if (PlayerNo == 2)
                {
                    this.Character = DodgeBlock.Avatar2;
                    this.Color = ConsoleColor.Yellow;

                }
                else
                {
                    this.Character = '@';
                    this.Color = ConsoleColor.Green;

                }
            }
        }
    }
}
