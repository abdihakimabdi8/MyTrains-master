using MyTrains.Core.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTrains.Core
{
    public class SendRepository
    {
        private readonly SQLiteAsyncConnection conn;
        public string StatusMessage { get; set; }
        Send  send;
        public SendRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Send>().Wait();
            conn.CreateTableAsync<Recipient>().Wait();
        }

        public async Task CreateSend(Send send)
        {
            try
            {
                // Basic validation to ensure we have a customer email.
                if (string.IsNullOrWhiteSpace(send.RecipientId.ToString()))
                    throw new Exception("Recipient Name is required");

                // Insert a new customer bill into the database
                var result = await conn.InsertAsync(send).ConfigureAwait(continueOnCapturedContext: false);
                StatusMessage = $"{result} record(s) added [Customer Email: {send.RecipientId})";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to create {send.RecipientId}'s bill. Error: {ex.Message}";
            }
        }

        public Task<List<Send>> GetAllSends()
        {
            // Return a list of transfers saved to the Send table in the database.
            //return conn.QueryAsync<Send>("select * from here StockId = ?", recipient.RecipeintId);
             return conn.Table<Send>().ToListAsync();
        }
    }
}