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

        public TeamController(ITeamRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
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
        public async Task<ActionResult<TeamModel>> PatchAsync([FromRoute] int id, [FromBody] TeamModel model){
            Team team = await _repository.GetByIdAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            // Null error in line 88
            team.Name = model.Name;
            team.Cnpj = model.Cnpj;

            _repository.Update(team);
            await _unitOfWork.CommitAsync();

            return Ok(model);
        }
    }
}