using AS_OOP_RacingTeams.Domain.Entities;
using AS_OOP_RacingTeams.Domain.Interfaces;
using AS_OOP_RacingTeams.Models;
using Microsoft.AspNetCore.Mvc;

namespace AS_OOP_RacingTeams.Controllers
{

    [Route("/api/teamRelationShip")]
    public class TeamRelationShipsController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonRepository _personRepository;
        private readonly ISponsorShipRepository _sponsorRepository;

        public TeamRelationShipsController(ITeamRepository teamRepository, IUnitOfWork unitOfWork, IPersonRepository personRepository, ISponsorShipRepository sponsorRepository)
        {
            _teamRepository = teamRepository;
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
            _sponsorRepository = sponsorRepository;
        }


        [HttpPost("/AddSponsorToTeam")]
        public async Task<IActionResult> PostSponsor([FromBody] AddSponsorToTeamModel model)
        {

            Team team = await _teamRepository.GetByIdAsync(model.TeamId);
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
            _teamRepository.Update(team);
            await _unitOfWork.CommitAsync();

            return Ok(team);
        }


        [HttpPost("/AddPersonToTeam")]
        public async Task<IActionResult> PostPerson([FromBody] AddPersonToTeamModel model)
        {
            Team team = await _teamRepository.GetByIdAsync(model.TeamId);
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
            _teamRepository.Update(team);
            await _unitOfWork.CommitAsync();

            return Ok(team);
        }



    }
}