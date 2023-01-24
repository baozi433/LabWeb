using LabWeb.CoreBusiness;
using LabWeb.DataStore.Contracts;
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
        public async Task<ActionResult<IEnumerable<PersonModel>>> GetPeople()
        {
            try
            {
                var people = await _peopleRepository.GetPeople();

                if (people == null) { return NotFound(); }
                else { return Ok(people); }
            }
            catch(Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("getpeople/{id}")]
        public async Task<ActionResult<PersonModel>> GetPeople(int id)
        {
            try
            {
                var people = await _peopleRepository.GetPeople(id);

                if (people == null) { return BadRequest();}
                else { return Ok(people); }
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
                var person = _peopleRepository.GetPeople(personModel.Id);
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
                var person = await _peopleRepository.GetPeople(id);
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
        public async Task<ActionResult<int>> UpdatePerson(int id)
        {
            try
            {
                var person = await _peopleRepository.GetPeople(id);
                if (person == null) { return NotFound("The person dose not exits"); }
                else
                {
                    var data = await _peopleRepository.Update(id);
                    return Ok(data);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("searchpeople/{filter}")]
        public async Task<ActionResult<PersonModel>> SearchPeople(string filter)
        {
            try
            {
                var people = await _peopleRepository.SearchPeople(filter);
                if (people == null) { return NotFound("The person dose not exits"); }
                else { return Ok(people); }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }




    }
}
