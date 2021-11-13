using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DodgeBlockFormsPort.MenuObjects;
using ConsoleGame.MenuObjects.CMSMobj;

namespace ConsoleGame.MenuObjects
{
    public static class CustomModeSettings
    {
        public static bool NotReturned = true;

        private static int ButtonCooldown = 0;

        private static MenuObject[] Menus = { new CustomReturn(), new Tick(),
            new Blocks(), new BoardWidth(), new BoardHeight() };

        public static void CMSMenu()
        {
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

                Board += @"\cf1\fs" + (int)(DodgeBlock.BoardSize / 1.5);




                Board += (
@"  -- Custom Mode Settings --  \line" +
@"                              \line" +
@"  Left&Right = Select/Deselect    Up&Down = Move/Change Value \line" +
@"\line                             ");

                for (int i = 0; i < Menus.Length; i++)
                {
                    if (i == select && selected)
                        BoardWriteLine(@"\cf0\highlight3" + " == " + Menus[i].Title + " ==" + @" \highlight0\cf1" + "\t");
                    else if (i == select)
                        BoardWriteLine(@"\cf0\highlight1" + "  * " + Menus[i].Title + " *" + @" \highlight0\cf1" + "\t");
                    else
                        BoardWriteLine("    " + Menus[i].Title + "\t" + "\t");
                }

                Board += @"\cf3";
                BoardWriteLine(@"\line         " + Menus[select].Value);
                Board += @"\cf1";

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
