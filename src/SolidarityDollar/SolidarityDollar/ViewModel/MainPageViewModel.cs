using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
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
            try
            {
                CultureInfo culture = new CultureInfo("en-US");

                CurrentRate = LastRates;


                if (CurrentRate != null)
                {
                    _valueRateDolarOficial = Convert.ToDouble(CurrentRate.RateOficial, culture);
                    _valueRateDolarSolidario = Convert.ToDouble(CurrentRate.RateSolidario, culture);
                    _valueRateDolarBlue = Convert.ToDouble(CurrentRate.RateBlue, culture);

                    //_dateDolarOficial = CurrentRate.RateDate.Date.ToShortDateString();
                    _dateDolarOficial = CurrentRate.RateDate.Date.ToString("MMMM dd, yyyy");

                }
            }
            catch (Exception e)
            {
                Crashes.TrackError(e);

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
            try
            {
                if (ValidarFormulario())
                {
                    //GoodJob
                    var DoubleResultOficial = Convert.ToDouble(_inputText) * _valueRateDolarOficial;

                    ResultOficial = FormatNumber(DoubleResultOficial);
                    ResultOficialSmall = string.Format("{0:0,0.##}", DoubleResultOficial);

                    var DoubleResultSolidario = Convert.ToDouble(_inputText) * _valueRateDolarSolidario;
                    ResultSolidario = FormatNumber(DoubleResultSolidario);
                    ResultSolidarioSmall = string.Format("{0:0,0.##}", DoubleResultSolidario);

                    var DoubleResultBlue = Convert.ToDouble(_inputText) * _valueRateDolarBlue;
                    ResultBlue = FormatNumber(DoubleResultBlue);
                    ResultBlueSmall = string.Format("{0:0,0.##}", DoubleResultBlue);

                }

            }
            catch (Exception e)
            {
                Crashes.TrackError(e);
            }
           
            //Dont Pass   


        }

        private bool ValidarFormulario()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(_inputText))
                {
                    return false;
                }
                if (!_inputText.ToCharArray().All(Char.IsNumber))
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                Crashes.TrackError(e);
                return false;
            }

          
        }

        static string FormatNumber(double num)
        {
            if (num >= 100000000)
            {
                return (num / 1000000D).ToString("0.#M");
            }
            if (num >= 1000000)
            {
                return (num / 1000000D).ToString("0.##M");
            }
            if (num >= 100000)
            {
                return (num / 1000D).ToString("0.#k");
            }
            if (num >= 10000)
            {
                return (num / 1000D).ToString("0.##k");
            }

            return num.ToString("#,0");
        }

        //result with mask with FormatNumber
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

        //result small font
        private string _resultOficialSmall;
        public string ResultOficialSmall
        {
            get => _resultOficialSmall;
            set
            {
                Set(ref _resultOficialSmall, value);
            }
        }

        private string _resultSolidarioSmall;
        public string ResultSolidarioSmall
        {
            get => _resultSolidarioSmall;
            set
            {
                Set(ref _resultSolidarioSmall, value);
            }
        }

        private string _resultBlueSmall;
        public string ResultBlueSmall
        {
            get => _resultBlueSmall;
            set
            {
                Set(ref _resultBlueSmall, value);
            }
        }








        //public Command<string> SpeachTranslationsCommand { get; } = new Command<string>(async (text) =>
        //{
        //    if (!string.IsNullOrWhiteSpace(text))
        //        await TextToSpeech.SpeakAsync(text);

        //}); 

    }
}
