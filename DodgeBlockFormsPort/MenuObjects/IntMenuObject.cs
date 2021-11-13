using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleGame;
using DodgeBlockFormsPort.MenuObjects;
namespace ConsoleGame.MenuObjects
{
    public abstract class IntMenuObject : MenuObject
    {
        public IntMenuObject()
        {
            Initialize();
        }

        public void Initialize()
        {
            this.Value = ProgramValue.ToString();
        }
        public bool looped;
        public int SettingsIndex;
        public int ProgramValue;
        public int minValue;
        public int maxValue;

        public override void ScaleUp()
        {
            if (ProgramValue < maxValue)
            {
                ProgramValue += 1;
                DodgeBlock.write.ToThisTxt(SettingsIndex, ProgramValue.ToString());
            }
            else if(looped)
            {
                ProgramValue = minValue;
                DodgeBlock.write.ToThisTxt(SettingsIndex, ProgramValue.ToString());
            }
            Value = ProgramValue.ToString();
        }
        public override void ScaleDown()
        {
            if (ProgramValue > minValue)
            {
                ProgramValue -= 1;
                DodgeBlock.write.ToThisTxt(SettingsIndex, ProgramValue.ToString());
            }
            else if (looped)
            {
                ProgramValue = maxValue;
                DodgeBlock.write.ToThisTxt(SettingsIndex, ProgramValue.ToString());
            }
            Value = ProgramValue.ToString();
        }
    }
}
