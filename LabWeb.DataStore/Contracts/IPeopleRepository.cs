using LabWeb.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWeb.DataStore.Contracts
{
    public interface IPeopleRepository
    {
        Task<List<PersonModel>> GetPeople();
        Task<List<PersonModel>> SearchPeople(string filter);
        Task DeletePerson(int id);
        Task Add(PersonModel person);
        Task Update(PersonModel person);
        Task<PersonModel> GetPeople(int id);

    }
}
