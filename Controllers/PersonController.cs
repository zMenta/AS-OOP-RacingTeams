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
                PersonDto personDto = new PersonDto
                {
                    Id = person.Id,
                    Name = person.Name,
                    Birth_year = person.Birth_year,
                    JobId = person.JobId,
                };

                 foreach(Team team in person.Teams)
                {
                    TeamRelationsDto teamRelationsDto = new TeamRelationsDto
                    {
                        Id = team.Id,
                        Name = team.Name, 
                        Cnpj = team.Cnpj                     
                    };
                }

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

            PersonDto personDto = new PersonDto
            {
                Id = person.Id,
                Name = person.Name,
                Birth_year = person.Birth_year,
                JobId = person.JobId,
            };

            return Ok(personDto);
        }

        [HttpPost]
        public async Task<ActionResult<PersonModel>> PostAsync([FromBody] PersonModel model)
        {
            Person person = new Person
            {
                Name = model.Name,
                Birth_year = model.Birth_year,
                JobId = model.JobId,
            };

            _repository.Save(person);
            await _unitOfWork.CommitAsync();

            PersonDto personDto = new PersonDto
            {
                Id = person.Id,
                Name = person.Name,
                Birth_year = person.Birth_year,
                JobId = person.JobId,
            };

            return Ok(personDto);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {

            bool deleted = _repository.Delete(id);

            if (deleted == false)
            {
                return NotFound();
            }

            await _unitOfWork.CommitAsync();
            return Ok("Deleted Person Id: " + id);
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<PersonModel>> PatchAsync([FromRoute] int id, [FromBody] PersonModel model){
            Person person = await _repository.GetByIdAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            person.Name = model.Name;
            person.Birth_year = model.Birth_year;
            person.JobId = model.JobId;

            _repository.Update(person);
            await _unitOfWork.CommitAsync();

            return Ok(model);
        }

    }
}