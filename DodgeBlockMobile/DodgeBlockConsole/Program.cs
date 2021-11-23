using System;
using System.Threading;
//using DodgeBlockConsole;

namespace ConsoleGame
{
    public class texbox
    {
        //public MainPage Parent;
        public texbox()//(MainPage parent)
        {
            //Parent = parent;
        }

        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
               // Parent.SetLabel1Text = value;
            }
        }

    }

    public class form
    {
        public Thread GameThread = new Thread(DodgeBlock.Game);
        public texbox ConsoleRrichTextBox;
        //public MainPage Parent;
        public form()//(MainPage parent)
        {
            ConsoleRrichTextBox = new texbox();// (parent);
            //Parent = parent;
        }


        public void TextBoxReplace(string Board)
        {
            Console.Clear();            
            if (Board == "")
            {
                Board = "DodgeBlock";
            }
            Console.Write(Board);
        }
        public void TextBoxWriteLine(string Board)
        {
            //ConsoleRrichTextBox.Text += "\n" + Board;
            Console.WriteLine(Board);
        }
        public void TextBoxWrite(string Board)
        {
            Console.Write(Board);
            /*
            Invoke(new Action(() =>
            {
                ConsoleRrichTextBox.Text += Board;
            }));*/
        }
        public void TextBoxWrite(char Board)
        {
            Console.Write(Board);
            /*
            Invoke(new Action(() =>
            {
                ConsoleRrichTextBox.Text += Board;
            }));*/
        }
        public void TextBoxReplaceRtf(string Board)
        {
            Console.Clear();
            string rw = Board;
            rw = rw.Replace(@"\line", "\n");
            rw = rw.Replace(@"\fs40", "");
            int ignore = 0;
            for (int i = 0; i < rw.Length; i++)
            {
                if ((rw + "   ").Substring(i, 3) == @"\cf")
                {
                    ConsoleColor color;
                    switch (rw.Substring(i, 4))
                    {
                        case @"\cf0":
                            color = ConsoleColor.Black;
                            break;
                        case @"\cf1":
                            color = ConsoleColor.White;
                            if ((rw + "    ").Substring(i, 5) == @"\cf10")
                            {
                                ignore = 1;
                            }
                            break;
                        case @"\cf2":
                            color = ConsoleColor.Green;
                            break;
                        case @"\cf3":
                            color = ConsoleColor.Yellow;
                            break;
                        case @"\cf4":
                            color = ConsoleColor.Magenta;
                            break;
                        case @"\cf5":
                            color = ConsoleColor.Red;
                            break;
                        case @"\cf6":
                            color = ConsoleColor.Blue;
                            break;
                        case @"\cf7":
                            color = ConsoleColor.Cyan;
                            break;
                        case @"\cf8":
                            color = ConsoleColor.DarkMagenta;
                            break;
                        case @"\cf9":
                            color = ConsoleColor.DarkGreen;
                            break;
                        /*case @"\cf10":
                            color = ConsoleColor.DarkGray;
                            break;*/
                        default:
                            color = ConsoleColor.White;
                            break;
                    }
                    Console.ForegroundColor = color;
                    ignore += 3;
                }
                else if ((rw + "   ").Substring(i, 3) == @"\hi")
                {
                    ConsoleColor bgcolor;
                    switch (rw.Substring(i, 11))
                    {
                        case @"\highlight0":
                            bgcolor = ConsoleColor.Black;
                            break; ;
                        case @"\highlight1":
                            bgcolor = ConsoleColor.White;
                            break;
                        case @"\highlight4":
                            bgcolor = ConsoleColor.Magenta;
                            break;
                        case @"\highlight2":
                            bgcolor = ConsoleColor.Green;
                            break;
                        case @"\highlight3":
                            bgcolor = ConsoleColor.Yellow;
                            break;
                        case @"\highlight5":
                            bgcolor = ConsoleColor.Red;
                            break;
                        case @"\highlight6":
                            bgcolor = ConsoleColor.Blue;
                            break;
                        case @"\highlight7":
                            bgcolor = ConsoleColor.Cyan;
                            break;
                        default:
                            bgcolor = ConsoleColor.Black;
                            break;
                    }
                    Console.BackgroundColor = bgcolor;
                    ignore = 10;
                }
                else if (ignore > 0)
                {
                    ignore -= 1;
                }
                else
                {
                    Console.Write(rw.Substring(i, 1));
                }
            } //(char obj in rw)
            
            //TextBoxReplace(rw);
            /*if (Parent.IsItPortrait())
                DodgeBlock.IsPortrait = true;
            else
                DodgeBlock.IsPortrait = false;
            
            string start = @"{\rtf1\ansi\deff0
{\colortbl;
\red255\green255\blue255;
\red0\green255\blue0;
\red255\green255\blue0;
\red255\green0\blue255;
\red255\green0\blue0;
\red0\green0\blue255;
\red0\green255\blue255;
\red255\green120\blue0;
\red0\green100\blue0;
\red224\green158\blue80;
}" + Board + "}";

            Invoke(new Action(() =>
            {
                try
                {
                    Form1_ResizeEnd(null, EventArgs.Empty);

                    ConsoleRrichTextBox.Rtf = start;
                }
                catch (NullReferenceException)
                {

                }
            }));*/
        }
        public void TextBoxWriteLineRtf(string Board)
        {/*
            Invoke(new Action(() =>
            {
                Form1_ResizeEnd(null, EventArgs.Empty);

                ConsoleRrichTextBox.Rtf =
                ConsoleRrichTextBox.Rtf.Substring(0, ConsoleRrichTextBox.Rtf.Length - 3)
                + Board + "}";
            }));*/
        }
        public void TextBoxChangeColor(int start, int length, object color)
        {/*
            Invoke(new Action(() =>
            {
                ConsoleRrichTextBox.Select(start, length);
                ConsoleRrichTextBox.SelectionColor = color;
            }));*/

        }
        public void TextBoxChangeColor(string find, object color)
        {/*
            Invoke(new Action(() =>
            {
                ConsoleRrichTextBox.Find(find);
                ConsoleRrichTextBox.SelectionColor = color;
            }));*/
        }

        public void CloseThis()
        {
            //ConsoleRrichTextBox.Parent.CloseThis();
        }
        public void GameInitialized()
        {/*
            Invoke(new Action(() =>
            {
                this.Text = DodgeBlock.Title;
                Form1_ResizeEnd(null, EventArgs.Empty);
            }));*/
        }
        public void BlueBackground(bool Bool)
        {
            //Parent.BlueBack(Bool);
        }
        public void OrangeBackground(bool Bool)
        {/*
            Invoke(new Action(() =>
            {
                if (Bool)
                {
                    ConsoleRrichTextBox.BackColor = Color.Orange;
                    this.BackColor = Color.Orange;
                    label1.ForeColor = Color.Orange;
                }
                else
                {
                    ConsoleRrichTextBox.BackColor = Color.Black;
                    this.BackColor = Color.Black;
                    label1.ForeColor = Color.Black;
                }
            }));*/
        }
        public float ZoomTextBox()
        {
            return 0;// (float)Parent.ZoomTextBox();
        }
        public void ZoomTextBox(float zoom, bool scene = false)
        {
            //Parent.ZoomTextBox(zoom);
        }
        public void Fullscreen(bool Bool)
        {/*
            Invoke(new Action(() =>
            {
                if (Bool)
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                }
                else
                {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    WindowState = FormWindowState.Normal;
                }
                Form1_ResizeEnd(null, EventArgs.Empty);
            }));*/
        }
    }

    public class Program
    {
        public static form form;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            form = new form();// parent);
            DodgeBlock.IsNetcore = true;
            form.GameThread.Start();
        }


    }

}
