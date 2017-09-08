using MyTrains.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTrains.Core.Contracts.Services
{
    public interface IUserDataService
    {
        Task<User> SearchUser(string userName);

        Task<User> Login(string userName, string password);

        User GetActiveUser();
    }
}
