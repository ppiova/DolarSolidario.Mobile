using System;
using SolidarityDollar.Data;
using SolidarityDollar.Models;
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

        private double _valueRateDolarOficial;
        public  double ValueRateDolarOficial
        {
            get => _valueRateDolarOficial;
            set => Set(ref _valueRateDolarOficial, value);
        }

        private double _valueRateDolarSolidario;
        public double ValueRateDolarSolidario
        {
            get => _valueRateDolarSolidario;
            set => Set(ref _valueRateDolarSolidario, value);
        }

        private double _valueRateDolarBlue;
        public double ValueRateDolarBlue
        {
            get => _valueRateDolarBlue;
            set => Set(ref _valueRateDolarBlue, value);
        }

      

        private string  _dateDolarOficial;
        public string DateDolarOficial
        {
            get => _dateDolarOficial;
            set => Set(ref _dateDolarOficial, value);
        }


        public MainPageViewModel()
        {
            CurrentRate = LastRates;

            if(CurrentRate != null)
            {
                _valueRateDolarOficial = Convert.ToDouble(CurrentRate.RateOficial);
                _valueRateDolarSolidario = Convert.ToDouble(CurrentRate.RateSolidario);
                _valueRateDolarBlue = Convert.ToDouble(CurrentRate.RateBlue);
         
                _dateDolarOficial = CurrentRate.RateDate.Date.ToShortDateString();
                                
            }
        }
               

        private string _inputText;
        public string InputText
        {
            get => _inputText;
            set
            {
                if (_inputText == value)
                    return;

                Set(ref _inputText, value);

                CalculateResults();
            }
        }

        public Command<string> CalculareRatesCommand => new Command<string>((inputText) =>
        {
            InputText = inputText;
        });

        private void CalculateResults()
        {
            //Controlar que no sea null el input, sino mensaje

            var DoubleResultOficial = Convert.ToDouble(_inputText) * _valueRateDolarOficial;
            ResultOficial = DoubleResultOficial.ToString();

            var DoubleResultSolidario = Convert.ToDouble(_inputText) * _valueRateDolarSolidario;
            ResultSolidario = DoubleResultSolidario.ToString();

            var DoubleResultBlue = Convert.ToDouble(_inputText) * _valueRateDolarBlue;
            ResultBlue = DoubleResultBlue.ToString();

     
        }


        private string _resultOficial;
        public string ResultOficial
        {
            get => _resultOficial;
            set
            {
                Set(ref _resultOficial, value);
            }
        }

        private string _resultSolidario;
        public string ResultSolidario
        {
            get => _resultSolidario;
            set
            {
                Set(ref _resultSolidario, value);
            }
        }

        private string _resultBlue;
        public string ResultBlue
        {
            get => _resultBlue;
            set
            {
                Set(ref _resultBlue, value);
            }
        }

       






        //public Command<string> SpeachTranslationsCommand { get; } = new Command<string>(async (text) =>
        //{
        //    if (!string.IsNullOrWhiteSpace(text))
        //        await TextToSpeech.SpeakAsync(text);

        //}); 

    }
}
