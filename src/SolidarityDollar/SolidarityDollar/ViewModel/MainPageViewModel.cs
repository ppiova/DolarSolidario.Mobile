using System;
using System.Collections.Generic;
using SolidarityDollar.Data;
using SolidarityDollar.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SolidarityDollar.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {

        public RateDolar LastRates => RateDataStore.LastRate;

        private RateDolar _currentRate;
        public RateDolar CurrentRate
        {
            get => _currentRate;
            set => Set(ref _currentRate, value);
        }

       

        private double ValueRateDolarOficial { get; set; }
        private double ValueRateDolarBlue { get; set; }
        private double ValueRateDolarSolidario { get; set; }
        private string DateDolarOficial { get; set; }

        public MainPageViewModel()
        {
            CurrentRate = LastRates;

            if(CurrentRate != null)
            {
                ValueRateDolarOficial = Convert.ToDouble(CurrentRate.RateOficial);
                ValueRateDolarBlue = Convert.ToDouble(CurrentRate.RateBlue);
                ValueRateDolarSolidario = Convert.ToDouble(CurrentRate.RateSolidario);
                DateDolarOficial = CurrentRate.RateDate.Date.ToShortDateString();
                                
            }
        }

        

        //public Command<string> SpeachTranslationsCommand { get; } = new Command<string>(async (text) =>
        //{
        //    if (!string.IsNullOrWhiteSpace(text))
        //        await TextToSpeech.SpeakAsync(text);

        //}); 

    }
}
