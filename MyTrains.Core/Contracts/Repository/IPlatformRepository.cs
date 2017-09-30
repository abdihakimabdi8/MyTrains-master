using System;
using System.Collections.Generic;
using MyTrains.Core.Model;
using MyTrains.Core.Models;
using System.Threading.Tasks;

namespace MyTrains.Core.Contracts.Repository
{
    public interface IPlatformRepository
    {
        Task<List<Platform>> GetAvailablePlatforms();
        Platform GetPlatformById(int platformId);

        string GetAboutContent();
    }
}
