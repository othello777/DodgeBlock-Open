using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Text;
using System.Threading;
using System.IO;
using ConsoleGame;

namespace DodgeBlockFormsPort
{

    public partial class Form1 : Form
    {
        public bool isfourtothree;
        public bool cutscene;
        public Thread GameThread = new Thread(DodgeBlock.Game);

        public Form1()
        {
            InitializeComponent();
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConsoleRrichTextBox.HideSelection = true;
            RunGame(null, EventArgs.Empty);
        }

        private void ConsoleRrichTextBox_Enter(object sender, EventArgs e)
        {
            // want to clear any current selection: use this:
            //richTextBox1.SelectionLength = 0;
            //richTextBox1.SelectionStart = 0;

            // what's unfortunate here is that
            // there is no simple way to turn-off
            // the cursor completely ... not without
            // ... as I understand it ... using pInvoke
            // whether any of the alternate cursors you
            // can change it to would be satisfactory
            // to you ... I don't have a clue !
            // Want a circle with a diagonal stripe:
            // richTextBox1.Cursor = Cursors.No;

            CodeButton.Focus();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (Width < Height * 1.4)
                isfourtothree = true;

            ConsoleRrichTextBox.Size = new Size(ActiveForm.Size.Width - 40, ActiveForm.Size.Height - 85);
            CodeBox.Width = ConsoleRrichTextBox.Width - 140;
            CodeBox.Text = DodgeBlock.SecretCode;
            DodgeBlock.BoardSize = ConsoleRrichTextBox.Size.Height / 10;
            if (ConsoleRrichTextBox.Size.Height < 500)
            {
                ConsoleRrichTextBox.ZoomFactor = 2;
            }
            else if (ConsoleRrichTextBox.Size.Height < 900)
            {
                ConsoleRrichTextBox.ZoomFactor = 3;
            }
            else if (ConsoleRrichTextBox.Size.Height < 2000)
            {
                ConsoleRrichTextBox.ZoomFactor = 4;
            }
            if (isfourtothree)
            {
                if (cutscene)
                    ConsoleRrichTextBox.ZoomFactor -= 1;
                DodgeBlock.BoardSize = (int)(DodgeBlock.BoardSize / 1.2);
            }

        }

        private void RunGame(object sender, EventArgs e)
        {
            GameThread.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GameThread.IsAlive)
            {
                GameThread.Abort();
            }

        }

        /*protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0112) // WM_SYSCOMMAND
            {
                // Check your window state here
                if (m.WParam == new IntPtr(0xF030)) // Maximize event - SC_MAXIMIZE from Winuser.h
                {
                    // THe window is being maximized
                    Form1_ResizeEnd(null, EventArgs.Empty);
                }
            }
            base.WndProc(ref m);
        }*/

        public void TextBoxReplace(string Board)
        {
            if (Board == "")
            {
                Board = "DodgeBlock";
            }
            Invoke(new Action(() =>
            {
                ConsoleRrichTextBox.Text = Board;
            }));
        }
        public void TextBoxWriteLine(string Board)
        {
            Invoke(new Action(() =>
            {
                ConsoleRrichTextBox.Text += "\n" + Board;
            }));
        }
        public void TextBoxWrite(string Board)
        {
            Invoke(new Action(() =>
            {
                ConsoleRrichTextBox.Text += Board;
            }));
        }
        public void TextBoxWrite(char Board)
        {
            Invoke(new Action(() =>
            {
                ConsoleRrichTextBox.Text += Board;
            }));
        }
        public void TextBoxReplaceRtf(string Board)
        {
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
            }));
        }
        public void TextBoxWriteLineRtf(string Board)
        {
            Invoke(new Action(() =>
            {
                Form1_ResizeEnd(null, EventArgs.Empty);

                ConsoleRrichTextBox.Rtf = 
                ConsoleRrichTextBox.Rtf.Substring(0, ConsoleRrichTextBox.Rtf.Length - 3) 
                + Board + "}";
            }));
        }
        public void TextBoxChangeColor(int start, int length, Color color)
        {
            Invoke(new Action(() =>
            {
                ConsoleRrichTextBox.Select(start, length);
                ConsoleRrichTextBox.SelectionColor = color;
            }));

        }
        public void TextBoxChangeColor(string find, Color color)
        {
            Invoke(new Action(() =>
            {
                ConsoleRrichTextBox.Find(find);
                ConsoleRrichTextBox.SelectionColor = color;
            }));
        }

        public void CloseThis()
        {
            Invoke(new Action(() =>
            {
                Close();
            }));
        }
        public void GameInitialized()
        {
            try
            {
                Invoke(new Action(() =>
                {
                    this.Text = DodgeBlock.Title;
                    Form1_ResizeEnd(null, EventArgs.Empty);
                }));
            }
            catch (Exception)
            {
                TextBoxWriteLine("ResizeError");
            }
        }
        public void BlueBackground(bool Bool)
        {
            Invoke(new Action(() =>
            {
                if (Bool)
                {
                    ConsoleRrichTextBox.BackColor = Color.Blue;
                    this.BackColor = Color.Blue;
                    label1.ForeColor = Color.Blue;
                }
                else
                {
                    ConsoleRrichTextBox.BackColor = Color.Black;
                    this.BackColor = Color.Black;
                    label1.ForeColor = Color.Black;
                }
            }));
        }
        public void OrangeBackground(bool Bool)
        {
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
            }));
        }
        public float ZoomTextBox()
        {
            float i = 0;
            Invoke(new Action(() =>
            {
                i = ConsoleRrichTextBox.ZoomFactor;
            }));
            return i;
        }
        public void ZoomTextBox(float zoom, bool scene = false)
        {
            Invoke(new Action(() =>
            {
                cutscene = scene;
                ConsoleRrichTextBox.ZoomFactor = zoom;
            }));
        }
        public void Fullscreen(bool Bool)
        {
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
            }));
        }


        private void CodeButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(DodgeBlock.SecretCode);
        }
    }



}

