using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleGame.GameObjects;

namespace ConsoleGame
{
    public class CustomModeC
    {
        public CustomModeC()
        {
            if (DodgeBlock.IsChristmas || DodgeBlock.IsHolloween)
                CustomModeAble = false;
            else
                CustomModeAble = true;
            
            BoardX = 12;
            BoardY = 7;
            Blocks = 1;
            Tick = 60;
        }

        public bool CustomModeAble;
        public int BoardX;
        public int BoardY;
        public int Blocks;
        public int Tick;

        public void SettingsChanged()
        {
            if(CustomModeAble && DodgeBlock.Mode == 4)
            {
                DodgeBlock.Tick = Tick;
                DodgeBlock.GameHeight = BoardY;
                DodgeBlock.GameWidth = BoardX;

                for (int i = 0; i < DodgeBlock.GameHeight; i++)
                {
                    for (int j = 0; j < DodgeBlock.GameWidth; j++)
                    {
                        DodgeBlock.BackBoard[j, i] = new BackDrop();
                    }
                }
                DodgeBlock.UseBoard = DodgeBlock.BackBoard.Clone() as GameObject[,];
            }
        }
    }
}
