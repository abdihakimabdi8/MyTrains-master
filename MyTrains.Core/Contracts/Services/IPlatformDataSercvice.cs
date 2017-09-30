using MyTrains.Core.Model;
using MyTrains.Core.Models;
using System;
using System.Collections.Generic;

namespace MyTrains.Core.Contracts.Services
{
    public interface IPlatformDataService
    {
        List<Platform> GetPlatforms();
        Platform GetActivePlatform();

        void SetActivePlatform(Platform platform);
        string GetAboutContent();
    }
}
