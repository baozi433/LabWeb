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
        Task<int> DeletePerson(int id);
        Task<int> Add(PersonModel person);
        Task<int> Update(int id);
        Task<PersonModel> GetPeople(int id);
        Task<int> GetLastRecord();

    }
}
