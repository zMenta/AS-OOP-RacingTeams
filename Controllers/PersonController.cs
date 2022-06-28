using AS_OOP_RacingTeams.Domain.Entities;
using AS_OOP_RacingTeams.Domain.Interfaces;
using AS_OOP_RacingTeams.Dto;
using AS_OOP_RacingTeams.Models;
using Microsoft.AspNetCore.Mvc;

namespace AS_OOP_RacingTeams.Controllers
{
    [Route("api/Person")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PersonController(IPersonRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonDto>>> GetAllAsync()
        {
            var personList = await _repository.GetAllAsync();
            


            return Ok(personList);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Person>> GetByIdAsync([FromRoute] int id)
        {
            Person person = await _repository.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

    }
}