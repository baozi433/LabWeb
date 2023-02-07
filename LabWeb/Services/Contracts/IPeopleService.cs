using LabWeb.CoreBusiness;

namespace LabWeb.Services.Contracts
{
    public interface IPeopleService
    {
        Task<List<PersonModelDto>> GetPeople();
        Task<PersonModelDto> GetPerson(int id);
        Task<List<PersonModelDto>> GetPeopleByCategory(int id);
        Task<List<PersonModelDto>> SearchPeople(string filter);
        Task<int> DeletePerson(int id);
        Task<int> Add(PersonModel person);
        Task<int> Update(PersonModel person);

    }
}
