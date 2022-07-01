using AS_OOP_RacingTeams.Domain.Entities;
using AS_OOP_RacingTeams.Domain.Interfaces;
using AS_OOP_RacingTeams.Models;
using AS_OOP_RacingTeams.Dto;
using Microsoft.AspNetCore.Mvc;
using AS_OOP_RacingTeams.Dto.DtoRelations;

namespace AS_OOP_RacingTeams.Controllers
{
    [Route("api/team")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonRepository _personRepository;

        private readonly ISponsorShipRepository _sponsorRepository;

        public TeamController(ITeamRepository repository, IUnitOfWork unitOfWork, IPersonRepository personRepository, ISponsorShipRepository sponsorRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
            _sponsorRepository = sponsorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeamDto>>> GetAllAsync()
        {
            IList<Team> teamList = await _repository.GetAllAsync();
            List<TeamDto> dtoList = new List<TeamDto>();

            foreach (Team team in teamList)
            {
                TeamDto teamDto = new TeamDto
                {
                    Id = team.Id,
                    Name = team.Name,
                    Cnpj = team.Cnpj,
                    
                };
                foreach(SponsorShip sponsorShip in team.SponsorShips)
                {
                    SponsorRelationsDto sponsorShipDto = new SponsorRelationsDto
                    {
                        Id = sponsorShip.Id,
                        Name = sponsorShip.Name,                      
                    };
                }
                

                dtoList.Add(teamDto);
            }

            return Ok(dtoList);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TeamDto>> GetByIdAsync([FromRoute] int id)
        {
            Team team = await _repository.GetByIdAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            TeamDto teamDto = new TeamDto
            {
                Id = team.Id,
                Name = team.Name,
                Cnpj = team.Cnpj,
            };

            return Ok(teamDto);
        }

        [HttpPost]
        public async Task<ActionResult<TeamModel>> PostAsync([FromBody] TeamModel model)
        {

            Team team = new Team
            {
                Name = model.Name,
                Cnpj = model.Cnpj,
            };

            _repository.Save(team);
            await _unitOfWork.CommitAsync();

            TeamDto teamDto = new TeamDto
            {
                Id = team.Id,
                Name = team.Name,
                Cnpj = team.Cnpj,
            };

            return Ok(teamDto);
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
            return Ok("Deleted Team Id: " + id);
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<TeamModel>> PatchAsync([FromRoute] int id, [FromBody] TeamModel model)
        {
            Team team = await _repository.GetByIdAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            team.Name = model.Name;
            team.Cnpj = model.Cnpj;

            _repository.Update(team);
            await _unitOfWork.CommitAsync();

            return Ok(model);
        }


        [HttpPost("/AddSponsorToTeam")]
        public async Task<IActionResult> PostSponsor([FromBody] AddSponsorToTeamModel model)
        {

            Team team = await _repository.GetByIdAsync(model.TeamId);
            SponsorShip sponsor = await _sponsorRepository.GetByIdAsync(model.SponsorShipId);

            if (team == null)
            {
                return NotFound();
            }

            if (sponsor == null)
            {
                return NotFound();
            }

            if (team.SponsorShips == null)
            {
                team.SponsorShips = new List<SponsorShip>();
            }

            team.SponsorShips.Add(sponsor);
            _repository.Update(team);
            await _unitOfWork.CommitAsync();

            return Ok(team);
        }

        [HttpPost("/AddPersonToTeam")]
        public async Task<IActionResult> PostPerson([FromBody] AddPersonToTeamModel model)
        {
            Team team = await _repository.GetByIdAsync(model.TeamId);
            Person person = await _personRepository.GetByIdAsync(model.PersonId);

            if (team == null)
            {
                return NotFound();
            }

            if (person == null)
            {
                return NotFound();
            }

            if (team.Persons == null)
            {
                team.Persons = new List<Person>();
            }

            team.Persons.Add(person);
            _repository.Update(team);
            await _unitOfWork.CommitAsync();

            return Ok(team);
        }

    }
}