using System;
using System.IO;
using System.Threading.Tasks;
using SolidarityDollar.Models;
using SQLite;

namespace SolidarityDollar.Services
{
    public class DatabaseService
    {
        SQLiteAsyncConnection conn;

        public DatabaseService()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "solidaritydolar.db");
            conn = new SQLiteAsyncConnection(databasePath);

        }

        public async Task<int> LastRate(RateDolar lastRate)
        {
            await conn.CreateTableAsync(typeof(RateDolar));

            return await conn.InsertAsync(lastRate);
        }

        public async Task<RateDolar> GetLastRate()
        {
            return await conn.Table<RateDolar>().OrderByDescending(d => d.Id).FirstOrDefaultAsync();
      
        }
    }
}
