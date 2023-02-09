using LabWeb.CoreBusiness;
using LabWeb.DataStore.Extensions;
using LabWeb.DataStore.Repositories.Contracts;
using LabWeb.Services.Contracts;
using System;

namespace LabWeb.Services
{
    public class PeopleServiceServer : IPeopleServiceServer
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleServiceServer(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }
        public async Task<int> Add(PersonModel person)
        {
            try
            {
                var response = await _peopleRepository.Add(person);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeletePerson(int id)
        {
            try
            {
                var response = await _peopleRepository.DeletePerson(id);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PersonModelDto>> GetPeopleDtos()
        {
            try
            {
                var response = await _peopleRepository.GetPeople();
                return response.ConvertToDto();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PersonModelDto>> GetPeopleByCategory(int id)
        {
            try
            {
                var response = await _peopleRepository.GetPeopleByCategory(id);
                return response.ConvertToDto();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PersonModelDto> GetPersonDto(int id)
        {
            try
            {
                var response = await _peopleRepository.GetPerson(id);
                return response.ConvertToDto();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PersonModelDto>> SearchPeopleDtos(string filter)
        {
            try
            {
                var response = await _peopleRepository.SearchPeople(filter);
                return response.ConvertToDto();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Update(PersonModel person)
        {
            try
            {
                var response = await _peopleRepository.Update(person);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PersonModel>> GetPeople()
        {
            try
            {
                var response = await _peopleRepository.GetPeople();
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PersonModel> GetPerson(int id)
        {
            try
            {
                var response = await _peopleRepository.GetPerson(id);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

       public async Task<List<PersonModel>> SearchPeople(string filter)
        {
            try
            {
                var response = await _peopleRepository.SearchPeople(filter);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> GetLastRecord()
        {
            try
            {
                var response = await _peopleRepository.GetLastRecord();
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
