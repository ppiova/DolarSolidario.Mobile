using System;
using System.Collections.Generic;
using SolidarityDollar.Models;

namespace SolidarityDollar.Data
{
    public class RateDataStore
    {
        public static RateDolar LastRate { get; set; } = new RateDolar();
    }
}
