using System;
using System.Collections.Generic;
using SolidarityDollar.Data;
using SolidarityDollar.Models;

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
            if(LastRates == null)
            {
                ValueRateDolarOficial = Convert.ToDouble(LastRates.RateOficial);
                ValueRateDolarBlue = Convert.ToDouble(LastRates.RateBlue);
                ValueRateDolarSolidario = Convert.ToDouble(LastRates.RateSolidario);
                DateDolarOficial = LastRates.RateDate.Date.ToShortDateString();

            }
        }

    }
}
