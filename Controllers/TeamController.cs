using AS_OOP_RacingTeams.Domain.Entities;
using AS_OOP_RacingTeams.Domain.Interfaces;
using AS_OOP_RacingTeams.Models;
using AS_OOP_RacingTeams.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AS_OOP_RacingTeams.Controllers
{
    [Route("api/team")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public TeamController(ITeamRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<Team>>> GetAllAsync()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Team>> GetByIdAsync([FromRoute] int id)
        {
            Team team = await _repository.GetByIdAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
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
    }
}