using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using SolidarityDollar.Models;

namespace SolidarityDollar.Services
{
    public class ApiRateService
    {

        public async Task<RateDolar> GetRateDolar()
        {
            
            try
            {
                
                var resultRate = new RateDolar();

                RateDolar result = await ApiKeys.ApiUrl
                .AppendPathSegment(ApiKeys.ControllerLastRate)
                .WithHeader("Ocp-Apim-Subscription-Key", ApiKeys.ApiKeyDolarSolidario)
                .GetJsonAsync<RateDolar>();

                resultRate.RateOficial = result.RateOficial;
                resultRate.RateBlue = result.RateBlue;
                resultRate.RateSolidario = result.RateSolidario;
                resultRate.RateDate = result.RateDate;

                //TODO: Save SQLLite for LastRates if DateRate is !=
                return resultRate;
            }
            catch
            {
                //TODO: Call SQLLite for LastRates
                var mockRate = new RateDolar
                {
                    RateOficial = "0",
                    RateBlue = "0",
                    RateSolidario = "0",
                    RateDate = new DateTime(1984, 9, 5, 18, 30, 00)
                };

                return mockRate;

            }
        }
    }
}
