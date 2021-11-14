using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DodgeBlockFormsPort.MenuObjects;

namespace ConsoleGame.MenuObjects
{
    public static class NewSettingsMenu
    {
        public static bool NotReturned = true;

        private static int ButtonCooldown = 0;

        private static MenuObject[] Menus = { new Return(), new Quit(), new Mode(),
            new CustomModeSettingsMenuObject(), new NewControls(), new God(),
            new Admin(), new Checkpoints(), new ResetScore(), new Credits()};


        public static void SettingsMenu()
        {
            DodgeBlock.music.PauseMusic();
            
            Program.form.BlueBackground(true);

            if (DodgeBlock.IsMobile && !DodgeBlock.IsPortrait)
                Program.form.ZoomTextBox(Program.form.ZoomTextBox() / 1.6f);
            else if (DodgeBlock.IsMobile && DodgeBlock.IsPortrait)
                Program.form.ZoomTextBox(Program.form.ZoomTextBox() / 1.3f);

            ButtonCooldown = 2;
            int initbutton = 4;
            int select = 0;
            bool selected = false;


            while (NotReturned)
            {
                string Board = "";
                
                    void BoardWriteLine(string Add)
                    {
                        Board += @"\line" + Add;
                    }

                    if (!DodgeBlock.IsMobile)
                        Board += @"\cf1\fs" + (int)(DodgeBlock.BoardSize / 1.5);

                    
                    string[] BoardToSide = new string[]
                    {
                "\t Left&Right = Select/Deselect",
                "\t   Up&Down = Move/Change Value",
                "\t          Current Score: " + DodgeBlock.Score,
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                ""
                    };



                    Board += (
  @"       -- Settings --         \line" +
  @"                              \line" +
  @"  Left&Right = Select/Deselect    Up&Down = Move/Change Value \line" +
   "  Current Score: " + DodgeBlock.Score +
  @"\line                             ");

                    for (int i = 0; i < Menus.Length; i++)
                    {
                        if (i == select && selected)
                            BoardWriteLine(" == " + Menus[i].Title + " ==" + "\t");
                        else if (i == select)
                            BoardWriteLine("  * " + Menus[i].Title + " *" + "\t");
                        else
                            BoardWriteLine("    " + Menus[i].Title + "\t" + "\t");
                        //if (Menus[i].GetType() == new ResetScore().GetType())
                        //    BoardWriteLine(@"\line###### Restart Settings ######\line");

                    }
                    if (!DodgeBlock.IsMobile)
                        Board += @"\cf3";
                    BoardWriteLine(@"\line         " + Menus[select].Value);
                    if (!DodgeBlock.IsMobile)
                        Board += @"\cf1";

                    /*BoardWriteLine(
    @"                              \line" +
    @"                              \line");*/

                    Program.form.TextBoxReplaceRtf(Board);
                

                

                if (NativeKeyboard.IsKeyDown(KeyCode.Up) && DodgeBlock.AdminPlayer2 == false ||
                NativeKeyboard.IsKeyDown(KeyCode.Up) && DodgeBlock.TwoPlayerMode == false ||
                    NativeKeyboard.IsKeyDown(KeyCode.W) && DodgeBlock.AdminPlayer2 && DodgeBlock.TwoPlayerMode)
                {
                    if (PressButton() || Menus[select].quickscroll && selected)
                    {
                        if (initbutton <= 0)
                        {
                            if (selected == false)
                                if (select > 0)
                                    select -= 1;
                                else
                                    select = Menus.Length - 1;

                        }

                        if (selected)
                            Menus[select].ScaleUp();

                    }
                }

                if (NativeKeyboard.IsKeyDown(KeyCode.Down) && DodgeBlock.AdminPlayer2 == false ||
                NativeKeyboard.IsKeyDown(KeyCode.Down) && DodgeBlock.TwoPlayerMode == false ||
                    NativeKeyboard.IsKeyDown(KeyCode.S) && DodgeBlock.AdminPlayer2 && DodgeBlock.TwoPlayerMode)
                {
                    if (PressButton() || Menus[select].quickscroll && selected)
                    {
                        if (initbutton <= 0)
                        {
                            if (selected == false)
                            {
                                if (select < Menus.Length - 1)
                                    select += 1;
                                else
                                    select = 0;
                            }
                        }

                        if (selected)
                            Menus[select].ScaleDown();

                    }
                }
                if (NativeKeyboard.IsKeyDown(KeyCode.Right) && DodgeBlock.AdminPlayer2 == false ||
                NativeKeyboard.IsKeyDown(KeyCode.Right) && DodgeBlock.TwoPlayerMode == false ||
                    NativeKeyboard.IsKeyDown(KeyCode.D) && DodgeBlock.AdminPlayer2 && DodgeBlock.TwoPlayerMode)
                {
                    if (PressButton())
                    {
                        if (selected == false)
                        {
                            selected = true;
                            Menus[select].OnActivate();
                        }
                    }
                }

                if (NativeKeyboard.IsKeyDown(KeyCode.Left) && DodgeBlock.AdminPlayer2 == false ||
                NativeKeyboard.IsKeyDown(KeyCode.Left) && DodgeBlock.TwoPlayerMode == false ||
                    NativeKeyboard.IsKeyDown(KeyCode.A) && DodgeBlock.AdminPlayer2 && DodgeBlock.TwoPlayerMode)
                {
                    if (PressButton())
                    {
                        if (selected)
                        {
                            selected = false;
                            Menus[select].OnDeactivate();
                        }
                    }
                }



                if (ButtonCooldown >= 0)
                    ButtonCooldown -= 1;
                if (initbutton >= 0)
                    initbutton -= 1;
                Thread.Sleep(100);
            }
            for (int i = 0; i < Menus.Length; i++)
            {
                Menus[i].Update();
            }


            NotReturned = true;
            ButtonCooldown = 0;
            select = 0;
            selected = false;
            DodgeBlock.InitConsoleColors();

            if (!DodgeBlock.ColorMode)
                Program.form.GameInitialized();
            
            Program.form.BlueBackground(false);

            if (DodgeBlock.IsMobile && !DodgeBlock.IsPortrait)
                Program.form.ZoomTextBox(Program.form.ZoomTextBox() * 1.6f);
            else if (DodgeBlock.IsMobile && DodgeBlock.IsPortrait)
                Program.form.ZoomTextBox(Program.form.ZoomTextBox() * 1.3f);

            if (DodgeBlock.MuteMusic == false)
                DodgeBlock.music.ResumeMusic();
            

        }

        static bool PressButton()
        {
            if (ButtonCooldown < 1)
            {
                ButtonCooldown = 2;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}