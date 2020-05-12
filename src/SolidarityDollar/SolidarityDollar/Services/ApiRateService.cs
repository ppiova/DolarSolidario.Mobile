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

        public async Task<List<RateDolar>> GetRateDolar()
        {
           
            
            try
            {
                //var client = new ImageSearchClient(new ApiKeyServiceClientCredentials(ApiKeys.BingImageSearch));

                var resultRate = new List<RateDolar>();

                var result = await ApiKeys.ApiUrl
                .AppendPathSegment(ApiKeys.Controller)
                .GetJsonAsync<List<RateDolar>>();


                resultRate.Add(new RateDolar
                {
                    RateOficial = result[0].RateOficial,
                    RateBlue = result[0].RateBlue,
                    RateSolidario = result[0].RateSolidario,
                    RateDate = result[0].RateDate

                }) ;
                return resultRate;
            }
            catch
            {
                return new List<RateDolar> {
                    new RateDolar
                    {
                        RateOficial = "0",
                        RateBlue = "0",
                        RateSolidario = "0",
                        RateDate = new DateTime(1984, 9, 5, 18, 30, 0)
                        //SQLLite
                        //Use DataBase LastRate
                        //RateOficial = result[0].RateOficial,
                        //RateBlue = result[0].RateBlue,
                        //RateSolidario = result[0].RateSolidario,
                        //RateDate = result[0].RateDate
                    }};
            }
        }
    }
}
