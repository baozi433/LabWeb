using LabWeb.CoreBusiness;

namespace LabWeb.Services.Contracts
{
    public interface IPeopleServiceServer
    {
        Task<List<PersonModelDto>> GetPeopleDtos();
        Task<PersonModelDto> GetPersonDto(int id);
        Task<List<PersonModelDto>> GetPeopleByCategory(int id);
        Task<List<PersonModelDto>> SearchPeopleDtos(string filter);
        Task<int> DeletePerson(int id);
        Task<int> Add(PersonModel person);
        Task<int> Update(PersonModel person);
        Task<List<PersonModel>> GetPeople();
        Task<PersonModel> GetPerson(int id);
        Task<List<PersonModel>> SearchPeople(string filter);
        Task<int> GetLastRecord();
    }
}
