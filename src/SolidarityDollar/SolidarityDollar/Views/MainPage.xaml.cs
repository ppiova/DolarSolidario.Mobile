using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SolidarityDollar.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void RateTextEntry_Completed(System.Object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RateTextEntry.Text))
            {
                await DisplayAlert("Atención", "¡No ingresaste ningún monto!", "OK");
                return;
            }
        }
    }
}
