using LabWeb.CoreBusiness;
using LabWeb.DataStore.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWeb.DataStore.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly ISqlDataAccess _DbContext;

        public UserAccountRepository(ISqlDataAccess DbContext)
        {
            _DbContext = DbContext;
        }
        public Task<int> AddUser(UserAccount userAccount)
        {
            var sql = "insert into dbo.UserAccount (UserName, Password, Role) values (@UserName, @Password, @Role)";
            return _DbContext.SaveData(sql, userAccount);
        }

        public Task<int> DeleteUser(UserAccount userAccount)
        {
            var sql = "delete from dbo.UserAccount where UserName = @UserName";
            return _DbContext.SaveData(sql, userAccount);
        }

        public Task<UserAccount> GetUserByName(string username)
        {
            var sql = "select * from dbo.UserAccount where UserName = @username";
            return _DbContext.LoadSingleData<UserAccount, dynamic>(sql, new {username = username});
        }

        public Task<int> UpdateUser(UserAccount userAccount)
        {
            var sql = "update dbo.UserAccount set UserName = @UserName, Password = @Password, Role = @Role where UserName = @UserName";
            return _DbContext.SaveData(sql, userAccount);
        }
    }
}
