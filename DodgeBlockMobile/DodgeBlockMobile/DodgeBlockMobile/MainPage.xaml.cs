using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ConsoleGame;
using Android.Content.Res;
using System.IO;

namespace DodgeBlockMobile
{
    public partial class MainPage : ContentPage
    {
        public static string settings;
        public bool sleeped = false;

        #region Ported Connections
        public bool UpButtonDown()
        {
            return UpButton.IsPressed;
        }
        public bool DownButtonDown()
        {
            return DownButton.IsPressed || sleeped;
        }
        public bool LeftButtonDown()
        {
            return LeftButton.IsPressed;
        }
        public bool RightButtonDown()
        {
            return RightButton.IsPressed;
        }
        public double ZoomTextBox()
        {
            return Label1.FontSize;
        }
        public void ZoomTextBox(double zoom)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Label1.FontSize = zoom;
            });
        }
        public void BlueBack(bool Bool)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (Bool)
                    BackgroundColor = Color.Blue;
                else
                    BackgroundColor = Color.Black;
            });
        }
        public bool IsItPortrait()
        {
            if (Width < Height)
                return true;
            else
                return false;
        }
        #endregion

        public static void sendsettings(string seti)
        {
            DodgeBlock.settingslocation = seti; //use this to store all the ser
        }

        public void CloseThis()
        {
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }

        private string myStringProperty;
        public string SetLabel1Text
        {
            get { return myStringProperty; }
            set
            {
                myStringProperty = value;
                OnPropertyChanged(nameof(SetLabel1Text)); // Notify that there was a change on this property

                Device.BeginInvokeOnMainThread(() =>
                {
                    Label1.Text = value;
                });
                
            }
        }
        public Thread GameThread = new Thread(DodgeBlock.Game);

        public MainPage()
        {
            InitializeComponent();
            SetLabel1Text = "init";
            BackgroundColor = Color.Black;
            Label1.TextColor = Color.White;
            if (Device.Idiom == TargetIdiom.Phone)
            {
                // You're on a phone
                Label1.FontSize = 17;
                spacelabel.IsEnabled = false;
            }
            else
            {
                // You're on a tablet
                Label1.FontSize = 30;
            }
            ButtonsContainer.HeightRequest = 70;
            DodgeBlock.IsMobile = true;
            
            GameThread.Start();
            Program prog = new Program(this);


        }

        public interface ICloseApplication
        {
            void closeApplication();
        }

        public string[] ReadAllLines(string filename)
        {
            string content;
            string[] cards = new string[] { "" }; //created a empty string array
            AssetManager assets = Android.App.Application.Context.Assets;
            using (StreamReader sr = new StreamReader(assets.Open("Settings.txt")))
            {
                content = sr.ReadToEnd();
            }

            cards = content.Split('\n');

            return cards;
        }


    }
}
