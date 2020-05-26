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
                //var client = new ImageSearchClient(new ApiKeyServiceClientCredentials(ApiKeys.BingImageSearch));

                var resultRate = new RateDolar();

                var result = await ApiKeys.ApiUrl
                .AppendPathSegment(ApiKeys.Controller)
                .GetJsonAsync<RateDolar>();

                resultRate.RateOficial = result.RateOficial;
                resultRate.RateBlue = result.RateBlue;
                resultRate.RateSolidario = result.RateSolidario;
                resultRate.RateDate = result.RateDate;
              

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
