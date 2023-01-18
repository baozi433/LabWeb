using LabWeb.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWeb.DataStore.Contracts
{
    internal interface IPeopleRepository
    {
        Task<List<PersonModel>> GetPeople();
        Task InsertPerson(PersonModel person);
        Task<List<PersonModel>> SearchPeople();
        Task DeletePerson(int Id);
        Task Add(PersonModel person);
        Task Update(PersonModel person);

    }
}
