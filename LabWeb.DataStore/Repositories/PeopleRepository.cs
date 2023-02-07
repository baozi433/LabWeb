using LabWeb.CoreBusiness;
using LabWeb.DataStore.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LabWeb.DataStore.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly ISqlDataAccess _DbContext;

        public PeopleRepository(ISqlDataAccess DbContext)
        {
            _DbContext = DbContext;
        }
        public Task<int> Add(PersonModel person)
        {
            string sql = "insert into dbo.People (Title, FirstName, LastName, ResearchArea, EmailAddress, Biography, ImageURL, WebLink, CategoryId) values (@Title, @FirstName, @LastName, @ResearchArea, @EmailAddress, @Biography, @ImageURL, @WebLink, @CategoryId)";
            return _DbContext.SaveData(sql, person);
        }

        public Task<int> DeletePerson(int id)
        {
            string sql = "delete from dbo.People where Id = @Id";
            return _DbContext.SaveData(sql, new {Id = id});
        }

        public Task<List<PersonModel>> GetPeople()
        {
            string sql = "select * from dbo.People";
            return _DbContext.LoadData<PersonModel, dynamic>(sql, new { });
        }

        public Task<List<PersonModel>> SearchPeople(string filter)
        {
            if(string.IsNullOrWhiteSpace(filter)) return GetPeople();

            string sql = "select * from dbo.People where FirstName like @FirstName";
            return _DbContext.LoadData<PersonModel, dynamic>(sql, new { FirstName = '%' + filter + '%'});
        }

        // using person object as parameter instead of id is to avoid dapper error
        public Task<int> Update(PersonModel person)
        {
            string sql = "update dbo.People set Title = @Title, FirstName = @FirstName, LastName = @LastName, ResearchArea = @ResearchArea, EmailAddress= @EmailAddress, Biography = @Biography, ImageURL = @ImageURL, WebLink = @WebLink, CategoryId = @CategoryId where Id = @Id";
            return _DbContext.SaveData(sql, person);
        }

        public Task<PersonModel> GetPerson(int id)
        {
            string sql = "select * from dbo.People where Id = @Id";
            return _DbContext.LoadSingleData<PersonModel, dynamic>(sql, new { Id = id });
        }
        public Task<int> GetLastRecord()
        {
            string sql = "select * from dbo.People where Id=(select max(Id) from dbo.People);";
            return _DbContext.LoadSingleData<int, dynamic>(sql, new { });
        }

        public Task<List<PersonCategory>> GetCategories()
        {
            string sql = "select * from dbo.PersonCategories";
            return _DbContext.LoadData<PersonCategory, dynamic>(sql, new{ });
        }

        public Task<PersonCategory> GetCategory(int id)
        {
            string sql = "select * from dbo.PersonCategories where Id = @Id";
            return _DbContext.LoadSingleData<PersonCategory, dynamic>(sql, new { Id = id });
        }

        public Task<List<PersonModel>> GetPeopleByCategory(int id)
        {
            string sql = "select * from dbo.People where CategoryId = @Id";
            return _DbContext.LoadData<PersonModel, dynamic>(sql, new { Id = id });
        }
    }
}
