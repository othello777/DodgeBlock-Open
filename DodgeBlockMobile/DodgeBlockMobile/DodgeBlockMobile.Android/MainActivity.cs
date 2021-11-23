using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using DodgeBlockMobile;
using Xamarin.Forms;
using Android.Content.Res;
using System.IO;

namespace DodgeBlockMobile.Droid
{
    [Activity(Label = "DodgeBlockMobile", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;


            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            // Read the contents of our asset
            /*string content;
            AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open("Settings.txt")))
            {
                content = sr.ReadToEnd();
            }
            DodgeBlockMobile.MainPage.sendsettings(content);
            TextView tv = new TextView(this);
            // Set TextView.Text to our asset content
            tv.Text = content;
            SetContentView(tv);*/
        }
    }
}