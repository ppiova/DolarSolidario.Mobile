using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AppCenter.Analytics;
using SolidarityDollar.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolidarityDollar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _mainPageViewModel = new MainPageViewModel();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = _mainPageViewModel;
        }


        private async void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            var analyticsData = new Dictionary<string, string> { { "Value", RateTextEntry.Text } };
            Analytics.TrackEvent("Speak Value", analyticsData);

            if (!string.IsNullOrWhiteSpace(RateTextEntry.Text))
              
            await TextToSpeech.SpeakAsync(RateTextEntry.Text);
           
        }

      
    }
}
