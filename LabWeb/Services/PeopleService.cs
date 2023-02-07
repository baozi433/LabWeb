using LabWeb.CoreBusiness;
using LabWeb.Services.Contracts;
using System;
using System.Collections.Generic;

namespace LabWeb.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly HttpClient _httpClient;

        public PeopleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> Add(PersonModel person)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"api/people/addperson/", person);
                return 1;
            }
            catch (HttpRequestException e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<int> DeletePerson(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/people/deleteperson/{id}");
                return 1;
            }
            catch (HttpRequestException e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<PersonModelDto>> GetPeople()
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/people/");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<PersonModelDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<PersonModelDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
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
                var response = await _httpClient.GetAsync($"api/people/GetPeopleByCategory/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<PersonModelDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<PersonModelDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PersonModelDto> GetPerson(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/people/getperson/{id}");
                if(response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(PersonModelDto);
                    }
                    return await response.Content.ReadFromJsonAsync<PersonModelDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PersonModelDto>> SearchPeople(string filter)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/people/searchpeople/{filter}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<PersonModelDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<PersonModelDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
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
                var response = await _httpClient.PatchAsJsonAsync($"api/people/updateperson/{person.Id}", person);
                return 1;
            }
            catch (HttpRequestException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
