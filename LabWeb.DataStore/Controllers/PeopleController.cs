using LabWeb.CoreBusiness;
using LabWeb.DataStore.Contracts;
using LabWeb.DataStore.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWeb.DataStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonModelDto>>> GetPeople()
        {
            try
            {
                var people = await _peopleRepository.GetPeople();

                if (people == null) { return NotFound(); }
                else 
                {
                    var peopleDtos = people.ConvertToDto();
                    return Ok(peopleDtos); 
                }
            }
            catch(Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("getperson/{id}")]
        public async Task<ActionResult<PersonModelDto>> GetPerson(int id)
        {
            try
            {
                var person = await _peopleRepository.GetPerson(id);

                if (person == null) { return BadRequest();}
                else 
                {
                    var personDto = person.ConvertToDto();
                    return Ok(personDto); 
                }
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost("addperson")]
        public async Task<ActionResult<int>> AddPerson(PersonModel personModel)
        {
            try
            {
                var person = _peopleRepository.GetPerson(personModel.Id);
                if (person == null) 
                {
                    var data = await _peopleRepository.Add(personModel);
                    return Ok(data);
                }
                else { return BadRequest("The person already exists"); }
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpDelete("deleteperson/{id}")]
        public async Task<ActionResult<int>> DeletePerson(int id)
        {
            try
            {
                var person = await _peopleRepository.GetPerson(id);
                if(person == null) { return NotFound("The person dose not exits");}
                else
                {
                    var data = await _peopleRepository.DeletePerson(id);
                    return Ok(data);
                }
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPatch("updateperson/{id}")]
        public async Task<ActionResult<int>> UpdatePerson(PersonModel person)
        {
            try
            {
                if (person == null) { return NotFound("The person dose not exits"); }
                else
                {
                    var data = await _peopleRepository.Update(person);
                    return Ok(data);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("searchpeople/{filter}")]
        public async Task<ActionResult<List<PersonModelDto>>> SearchPeople(string filter)
        {
            try
            {
                var people = await _peopleRepository.SearchPeople(filter);
                if (people == null) { return NotFound("The person dose not exits"); }
                else 
                {
                    var peopleDtos = people.ConvertToDto();
                    return Ok(peopleDtos); 
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet(nameof(GetPeopleCategories))]
        public async Task<ActionResult<List<PersonCategory>>> GetPeopleCategories()
        {
            try
            {
                var peopleCategories = await _peopleRepository.GetCategories();
                if (peopleCategories == null) { return NotFound(); }
                else{ return Ok(peopleCategories); }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }




    }
}
