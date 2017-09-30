using System.Collections.Generic;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.Model;
using MyTrains.Core.Models;
using System.Threading.Tasks;

namespace MyTrains.Core.Services.Data
{
    public class PlatformDataService /*: IPlatformDataService*/
    {
        private readonly IPlatformRepository _platformRepository;
        private Platform _activePlatform;

        public PlatformDataService(IPlatformRepository platformRepository)
        {
           _platformRepository = platformRepository;
        }
        public Task<List<Platform>> GetPlatforms()
        {
            return _platformRepository.GetAvailablePlatforms();
        }

        public Platform GetActivePlatform()
        {
            return _activePlatform ?? (_activePlatform = _platformRepository.GetPlatformById(1));
        }

        public void SetActivePlatform(Platform platform)
        {
            _activePlatform = platform;
        }

        public string GetAboutContent()
        {
            return _platformRepository.GetAboutContent();
        }
    }
}