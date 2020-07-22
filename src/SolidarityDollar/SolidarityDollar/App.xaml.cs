using System;
using SolidarityDollar.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Lato-Black.ttf", Alias = "LatoBlack")]
[assembly: ExportFont("Lato-Bold.ttf", Alias = "LatoBold")]
[assembly: ExportFont("Lato-Regular.ttf", Alias = "LatoRegular")]
[assembly: ExportFont("fa-regular.otf", Alias = "FontAwesomeRegular")]
[assembly: ExportFont("fa-solid.otf", Alias = "FontAwesomeSolid")]


namespace SolidarityDollar
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Device.SetFlags(new[] { "Shapes_Experimental", "MediaElement_Experimental" });
            MainPage = new SplashScreen();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
