using System.Collections.Generic;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Model;
using MyTrains.Core.Models;
using SQLite;
using System;
using System.Threading.Tasks;

namespace MyTrains.Core.Repositories
{
    public class PlatformRepository /*: IPlatformRepository*/
    {

        private readonly SQLiteAsyncConnection conn;

        public string StatusMessage { get; set; }

        public PlatformRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Platform>().Wait();
        }

        public async Task CreatePlatform(Platform platform)
        {
            try
            {
                // Basic validation to ensure we have a customer email.
                if (string.IsNullOrWhiteSpace(platform.PlatformName))
                    throw new Exception("Recipient Name is required");

                // Insert a new customer bill into the database
                var result = await conn.InsertAsync(platform).ConfigureAwait(continueOnCapturedContext: false);
                StatusMessage = $"{result} record(s) added [Customer Email: {platform.PlatformName})";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to create {platform.PlatformName}'s bill. Error: {ex.Message}";
            }
        }

        public Task<List<Platform>> GetAvailablePlatforms()
        {
            // Return a list of bills saved to the Bill table in the database.
            return conn.Table<Platform>().ToListAsync();
        }

        //public async Task<Platform> GetPlatformyByIdAsync(int platformId)
        //{
        //    Task<IList<Platform>> = AllPlatforms await GetAvailablePlatforms();
        //    return AllPlatforms[platformId];
        //}

        public string GetAboutContent()
        {
            return "Leverage agile frameworks to provide a robust synopsis for high level overviews. Iterative approaches to corporate strategy foster collaborative thinking to further the overall value proposition. Organically grow the holistic world view of disruptive innovation via workplace diversity and empowerment.";
        }
    }
}