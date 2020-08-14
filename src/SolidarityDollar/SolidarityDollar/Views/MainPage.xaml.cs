using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            if (await ValidarFormulario())
            {
                //GoodJob
            }
               //Dont Pass      


        }
        private async Task<bool> ValidarFormulario()
        {
            //Valida si el valor en el Entry se encuentra vacio o es igual a Null
            if (String.IsNullOrWhiteSpace(RateTextEntry.Text))
            {
                await this.DisplayAlert("Advertencia", "Debe ingresar un monto", "OK");
                return false;
            }
            //Valida que solo se ingresen números
            else if (!RateTextEntry.Text.ToCharArray().All(Char.IsNumber))
            {
                await this.DisplayAlert("Advertencia", "Ingrese solo números, favor de validar.", "OK");
                return false;
            }
            //else
            //{
            //    //Valida si se ingresan caracteres especiales
            //    string caractEspecial = @"^[^ ][a-zA-Z ]+[^ ]$";
            //    bool resultado = Regex.IsMatch(RateTextEntry.Text, caractEspecial, RegexOptions.IgnoreCase);
            //    if (!resultado)
            //    {
            //        await this.DisplayAlert("Advertencia", "No se aceptan caracteres especiales, intente de nuevo.", "OK");
            //        return false;
            //    }
            //}

          
            return true;
        }


        private async void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(RateTextEntry.Text))
                await TextToSpeech.SpeakAsync(RateTextEntry.Text);
        }

      
    }
}
