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
        private readonly ISqlDataAccess _sqlDataAccess;

        public PeopleRepository(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }
        public Task Add(PersonModel person)
        {
            throw new NotImplementedException();
        }

        public Task DeletePerson(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonModel>> GetPeople()
        {
            throw new NotImplementedException();
        }

        public Task InsertPerson(PersonModel person)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonModel>> SearchPeople()
        {
            throw new NotImplementedException();
        }

        public Task Update(PersonModel person)
        {
            throw new NotImplementedException();
        }
    }
}
