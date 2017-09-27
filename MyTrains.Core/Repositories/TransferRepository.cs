using MyTrains.Core.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTrains.Core
{
    public class TransferRepository
    {
        private readonly SQLiteAsyncConnection conn;

        public string StatusMessage { get; set; }

        public TransferRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Transfer>().Wait();
        }

        public async Task CreateTransfer(Transfer transfer)
        {
            try
            {
                // Basic validation to ensure we have a customer email.
                if (string.IsNullOrWhiteSpace(transfer.Recipient))
                    throw new Exception("Recipient Name is required");

                // Insert a new customer bill into the database
                var result = await conn.InsertAsync(transfer).ConfigureAwait(continueOnCapturedContext: false);
                StatusMessage = $"{result} record(s) added [Customer Email: {transfer.Recipient})";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to create {transfer.Recipient}'s bill. Error: {ex.Message}";
            }
        }

        public Task<List<Transfer>> GetAllTransfers()
        {
            // Return a list of bills saved to the Bill table in the database.
            return conn.Table<Transfer>().ToListAsync();
        }
    }
}