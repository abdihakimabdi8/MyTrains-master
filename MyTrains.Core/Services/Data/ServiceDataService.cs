using System.Collections.Generic;
using System.Threading.Tasks;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.Model;

namespace MyTrains.Core.Services.Data
{
    public class ServiceDataService : IServiceDataService
    {
        private readonly IServiceRepository _serviceRepository;
        public ServiceDataService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public virtual async Task<List<Service>> GetAllServices()
        {
            return await _serviceRepository.GetAllServices();
        }

        public async Task<Service> GetServiceById(int serviceId)
        {
            return await _serviceRepository.GetServiceById(serviceId);
        }
    }
}