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
            IList<Person> personList = await _repository.GetAllAsync();
            List<PersonDto> dtoList = new List<PersonDto>();

            foreach (Person person in personList)
            {
                PersonDto personDto = new PersonDto()
                {
                    Id = person.Id,
                    Name = person.Name,
                    Birth_year = person.Birth_year,
                    JobId = person.JobId,
                };

                dtoList.Add(personDto);
            }

            return Ok(dtoList);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<PersonDto>> GetByIdAsync([FromRoute] int id)
        {
            Person person = await _repository.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            PersonDto personDto = new PersonDto()
            {
                Id = person.Id,
                Name = person.Name,
                Birth_year = person.Birth_year,
                JobId = person.JobId,
            };

            return Ok(personDto);
        }

    }
}