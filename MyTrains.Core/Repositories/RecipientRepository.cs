using MyTrains.Core.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTrains.Core
{
    public class RecipientRepository
    {
        private readonly SQLiteAsyncConnection conn;

        public string StatusMessage { get; set; }

        public RecipientRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Recipient>().Wait();
        }

        public async Task CreateRecipient(Recipient recipient)
        {
            try
            {
                // Basic validation to ensure we have a customer email.
                if (string.IsNullOrWhiteSpace(recipient.RecipientName))
                    throw new Exception("Recipient Name is required");

                // Insert a new customer bill into the database
                var result = await conn.InsertAsync(recipient).ConfigureAwait(continueOnCapturedContext: false);
                StatusMessage = $"{result} record(s) added [Customer Email: {recipient.RecipientName})";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to create {recipient.RecipientName}'s bill. Error: {ex.Message}";
            }
        }

        public Task<List<Recipient>> GetAllRecipients()
        {
            // Return a list of bills saved to the Bill table in the database.
            return conn.Table<Recipient>().ToListAsync();
        }

        //public Recipient GetCurrencyById(int recipientId)
        //{
        //    return AllRecipients[recipientId];
        //}

        public string GetSendContentTitle()
        {
            return "Send money with love Instant, no fee transfers from the US, UK, and Canada to Ghana and East Africa with the best rates.";
        }
        public string GetSendContentBody()
        {
            return "Instant, no fee transfers from the US, UK, and Canada to Ghana and East Africa with the best rates.";
        }
    }
}