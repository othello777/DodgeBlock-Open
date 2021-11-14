using System;
using System.Net;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using ConsoleGame.GameObjects;
using ConsoleGame.MenuObjects;
using ConsoleGame;
using othello7Library;
using DodgeBlockFormsPort;
using DodgeBlockMobile;

namespace ConsoleGame
{
    public class texbox
    {
        public MainPage Parent;
        public texbox(MainPage parent)
        {
            Parent = parent;
        }

        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                Parent.SetLabel1Text = value;
            }
        }

    }

    public class form
    {
        public texbox ConsoleRrichTextBox;
        public MainPage Parent;
        public form(MainPage parent)
        {
            ConsoleRrichTextBox = new texbox(parent);
            Parent = parent;
        }


        public void TextBoxReplace(string Board)
        {
            if (Board == "")
            {
                Board = "DodgeBlock";
            }
            ConsoleRrichTextBox.Text = Board;
        }
        public void TextBoxWriteLine(string Board)
        {
            ConsoleRrichTextBox.Text += "\n" + Board;
        }
        public void TextBoxWrite(string Board)
        {/*
            Invoke(new Action(() =>
            {
                ConsoleRrichTextBox.Text += Board;
            }));*/
        }
        public void TextBoxWrite(char Board)
        {/*
            Invoke(new Action(() =>
            {
                ConsoleRrichTextBox.Text += Board;
            }));*/
        }
        public void TextBoxReplaceRtf(string Board)
        {
            string rw = Board;
            rw = rw.Replace(@"\line", "\n");
            rw = rw.Replace(@"\highlight0", "");
            rw = rw.Replace(@"\fs40", "");
            TextBoxReplace(rw);
            if (Parent.IsItPortrait())
                DodgeBlock.IsPortrait = true;
            else
                DodgeBlock.IsPortrait = false;
            /*
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
            ConsoleRrichTextBox.Parent.CloseThis();
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
            Parent.BlueBack(Bool);
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
            return (float)Parent.ZoomTextBox();
        }
        public void ZoomTextBox(float zoom, bool scene = false)
        {
            Parent.ZoomTextBox(zoom);
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

        public Program(MainPage parent)
        {
            form = new form(parent);
        }


    }

}