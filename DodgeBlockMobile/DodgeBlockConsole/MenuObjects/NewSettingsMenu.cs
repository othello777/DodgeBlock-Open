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

        private static MenuObject[] Menus = { new Return(), new Quit(),
            new Mode(), new CustomModeSettingsMenuObject(),
            new God(), new Admin(), new Checkpoints(), new ResetScore(), new Credits()};


        public static void SettingsMenu()
        {

            DodgeBlock.music.PauseMusic();

            if (DodgeBlock.ColorMode)
                Program.form.BlueBackground(true);
            else
                Program.form.ZoomTextBox(Program.form.ZoomTextBox() / 1.5f);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;

            ButtonCooldown = 2;
            int initbutton = 4;
            int select = 0;
            bool selected = false;


            while (NotReturned)
            {
                string Board = "";
                if (DodgeBlock.ColorMode)
                {
                    void BoardWriteLine(string Add)
                    {
                        Board += @"\line" + Add;
                    }

                    Board += @"\cf1\fs" + (int)(DodgeBlock.BoardSize / 1.7);

                    /*
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
                    };*/



                    Board += (
  @"       -- Settings --         \line" +
  @"                              \line" +
  @"  Left&Right = Select/Deselect    Up&Down = Move/Change Value \line" +
   "  Current Score: " + DodgeBlock.Score +
  @"\line                             ");

                    for (int i = 0; i < Menus.Length; i++)
                    {
                        if (i == select && selected)
                            BoardWriteLine(@"\cf0\highlight3" + " == " + Menus[i].Title + " ==" + @" \highlight6\cf1" + "\t");
                        else if (i == select)
                            BoardWriteLine(@"\cf0\highlight1" + "  * " + Menus[i].Title + " *" + @" \highlight6\cf1" + "\t");
                        else
                            BoardWriteLine("    " + Menus[i].Title + "\t" + "\t");

                    }

                    Board += @"\cf3";
                    BoardWriteLine(@"\line         " + Menus[select].Value);
                    Board += @"\cf1";

                    Program.form.TextBoxReplaceRtf(Board);
                }

                


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

                NativeKeyboard.Update();

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
            DodgeBlock.customModeC.SettingsChanged();

            NotReturned = true;
            ButtonCooldown = 0;
            select = 0;
            selected = false;
            DodgeBlock.InitConsoleColors();

            if (!DodgeBlock.ColorMode)
                Program.form.GameInitialized();
            
            Program.form.BlueBackground(false);

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