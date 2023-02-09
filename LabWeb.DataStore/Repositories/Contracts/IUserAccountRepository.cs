using LabWeb.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWeb.DataStore.Repositories.Contracts
{
    public interface IUserAccountRepository
    {
        Task<UserAccount> GetUserByName(string username);
        Task<int> AddUser(UserAccount userAccount);
        Task<int> UpdateUser(UserAccount userAccount);
        Task<int> DeleteUser(UserAccount userAccount);
    }
}
