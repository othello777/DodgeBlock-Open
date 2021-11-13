using System;

namespace ConsoleGame.MenuObjects
{
    public abstract class BoolMenuObject : MenuObject
    {
        public BoolMenuObject()
        {
            Initialize();
        }

        public void Initialize()
        {
            if (ProgramValue)
                this.Value = TrueValue;
            else
                this.Value = FalseValue;
        }

        public string TrueValue;
        public string FalseValue;
        public int SettingsIndex;
        public bool ProgramValue;

        public override void ScaleUp()
        {
            bool Bool = Toggle(ProgramValue, FalseValue, TrueValue);
            ProgramValue = Bool;
            DodgeBlock.write.ToThisTxt(SettingsIndex, DodgeBlock.Boolconvert(Bool));
        }
        public override void ScaleDown()
        {
            bool Bool = Toggle(ProgramValue, FalseValue, TrueValue);
            ProgramValue = Bool;
            DodgeBlock.write.ToThisTxt(SettingsIndex, DodgeBlock.Boolconvert(Bool));
        }
    }
}
