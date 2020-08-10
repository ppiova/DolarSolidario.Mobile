using System;
using System.Collections.Generic;
using System.Globalization;
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




        private async void RateTextEntry_Completed(System.Object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RateTextEntry.Text))
            {
                await DisplayAlert("Atención", "¡No ingresaste ningún monto!", "OK");
                return;
            }

           
        }


        private async void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(RateTextEntry.Text))
                await TextToSpeech.SpeakAsync(RateTextEntry.Text);
        }


    }
}
