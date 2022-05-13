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
using Xamarin.Forms;

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
            string stripped = "";
            bool tagopen = false;
            FormattedString formattedString = new FormattedString();
            Xamarin.Forms.Color NextColor = Xamarin.Forms.Color.White;

            int ignore = 0;
            for (int i = 0; i < rw.Length; i++)
            {
                if ((rw + "   ").Substring(i, 3) == @"\cf")
                {
                    void setcolor(int r, int g, int b)
                    { 
                        //var span = new Span { Text = "default, " };
                        

                        if (tagopen)
                        {
                            formattedString.Spans.Add(new Span { Text = stripped, ForegroundColor = NextColor});
                            stripped = "";
                        }
                        //stripped += ("<strong style=\"color:red\">");
                        NextColor = new Xamarin.Forms.Color(r, g, b);
                        tagopen = true;
                    }

                    switch (rw.Substring(i+3, 1))
                    {
                        case "0":
                            setcolor(0, 0, 0);
                            break;
                        case "1":
                            if ((rw + "    ").Substring(i, 5) == @"\cf10")
                            {
                                ignore = 1;
                                break;
                            }
                            setcolor(0xFF, 0xFF, 0xFF);
                            break;
                        case "2":
                            setcolor(0, 255, 0);
                            break;
                        case "3":
                            setcolor(255, 255, 0);
                            break;
                        case "4":
                            setcolor(255, 0, 255);
                            break;
                        case "5":
                            setcolor(255, 0, 0);
                            break;
                        case "6":
                            setcolor(0, 0, 255);
                            break;
                        case "7":
                            setcolor(0, 255, 255);
                            break;
                        case "8":
                            setcolor(255, 120, 0);
                            break;
                        case "9":
                            setcolor(0, 100, 0);
                            break;
                        default:
                            //startofline = true;
                            break;
                    }

                    /*switch (rw.Substring(i, 4))
                    {
                        case @"\cf0":
                            break;
                        case @"\cf1":
                            if ((rw + "    ").Substring(i, 5) == @"\cf10")
                            {
                                ignore = 1;
                            }
                            break;
                        case @"\cf2":
                            break;
                        case @"\cf3":
                            break;
                        case @"\cf4":
                            break;
                        case @"\cf5":
                            break;
                        case @"\cf6":
                            break;
                        case @"\cf7":
                            break;
                        case @"\cf8":
                            break;
                        case @"\cf9":
                            break;
                        default:
                            break;
                    }*/
                    //Console.ForegroundColor = color;
                    ignore += 3;
                }
                else if ((rw + "   ").Substring(i, 3) == @"\hi")
                {
                    ignore = 10;
                }
                else if (ignore > 0)
                {
                    ignore -= 1;
                }
                else
                {
                    stripped += rw.Substring(i, 1);
                }
            }
            if (tagopen)
                formattedString.Spans.Add(new Span { Text = stripped, ForegroundColor = NextColor });
            
            //TextBoxReplace(stripped);
            if (Parent.IsItPortrait())
                DodgeBlock.IsPortrait = true;
            else
                DodgeBlock.IsPortrait = false;

            /*string start = @"{\rtf1\ansi\deff0
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
}" + Board + "}";*/

            /*Invoke(new Action(() =>
            {
                try
                {
                    Form1_ResizeEnd(null, EventArgs.Empty);
*/
            Parent.SetLabel1FormattedText = formattedString;
            //ConsoleRrichTextBox.Text = stripped;
                /*}
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