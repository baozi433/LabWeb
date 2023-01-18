using LabWeb.CoreBusiness;
using LabWeb.DataStore.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public Task Add(PersonModel person)
        {
            string sql = "insert into dbo.People (Title, FirstName, LastName, ResearchArea, EmailAddress, Biography, ImageURL) " +
                         "values (@Title, @FirstName, @LastName, @ResearchArea, @EmailAddress, @Biography, @ImageURL)";
            return _DbContext.SaveData(sql, person);
        }

        public Task DeletePerson(int Id)
        {
            string sql = "delete from dbo.People where id = @Id";
            return _DbContext.SaveData(sql, new {Id = Id});
        }

        public Task<List<PersonModel>> GetPeople()
        {
            string sql = "select * from dbo.People";
            return _DbContext.LoadData<PersonModel, dynamic>(sql, new { });
        }

        public Task<List<PersonModel>> SearchPeople(string filter)
        {
            if(string.IsNullOrWhiteSpace(filter)) return GetPeople();

            string sql = "select * from dbo.People where FirstName = @FirstName";
            return _DbContext.LoadData<PersonModel, dynamic>(sql, new { FirstName = filter});
        }

        public Task Update(PersonModel person)
        {
            string sql = "update dbo.People set Title = @Title, FirstName = @FirstName, LastName = @LastName," +
                         " ResearchArea = @ResearchArea, EmailAddress= @EmailAddress, Biography = @Biography, ImageURL = @ImageURL WHERE Id = @Id";
            return _DbContext.SaveData(sql, new { person });
        }
    }
}
