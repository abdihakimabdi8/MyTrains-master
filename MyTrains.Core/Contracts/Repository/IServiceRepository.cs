﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTrains.Core.Model;

namespace MyTrains.Core.Contracts.Repository
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetAllServices();

        Task<Service> GetServiceById(int serviceId);
    }
}
