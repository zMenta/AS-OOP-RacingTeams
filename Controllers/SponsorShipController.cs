using AS_OOP_RacingTeams.Domain.Entities;
using AS_OOP_RacingTeams.Domain.Interfaces;
using AS_OOP_RacingTeams.Dto;
using AS_OOP_RacingTeams.Models;
using Microsoft.AspNetCore.Mvc;

namespace AS_OOP_RacingTeams.Controllers
{
    [Route("api/sponsorship")]
    public class SponsorShipController : ControllerBase
    {
        private readonly ISponsorShipRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public SponsorShipController(ISponsorShipRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<SponsorShipDto>>> GetAllAsync()
        {
            IList<SponsorShip> sponsorShipsList = await _repository.GetAllAsync();
            List<SponsorShipDto> dtoList = new List<SponsorShipDto>();

            foreach (SponsorShip sponsor in sponsorShipsList)
            {
                SponsorShipDto sponsorShipDto = new SponsorShipDto()
                {
                    Id = sponsor.Id,
                    Name = sponsor.Name,
                };

                foreach (Team team in sponsor.Teams)
                {
                    TeamRelationsDto teamRelationsDto = new TeamRelationsDto
                    {
                        Id = team.Id,
                        Name = team.Name,  
                        Cnpj = team.Cnpj                    
                    };
                }

                dtoList.Add(sponsorShipDto);
            }

            return Ok(dtoList);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<SponsorShipDto>> GetByIdAsync([FromRoute] int id)
        {
            SponsorShip sponsorShip = await _repository.GetByIdAsync(id);
            if (sponsorShip == null)
            {
                return NotFound();
            }

            SponsorShipDto sponsorDto = new SponsorShipDto
            {
                Name = sponsorShip.Name,
                Id = sponsorShip.Id,
            };

            return Ok(sponsorDto);
        }


        [HttpPost]
        public async Task<ActionResult<SponsorShipModel>> PostAsync([FromBody] SponsorShipModel model)
        {
            SponsorShip sponsorShip = new SponsorShip
            {
                Name = model.Name
            };

            _repository.Save(sponsorShip);
            await _unitOfWork.CommitAsync();

            return Ok(sponsorShip);
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
            return Ok("Deleted SponsorShip Id: " + id);
        }


        [HttpPatch("{id:int}")]
        public async Task<ActionResult<SponsorShipDto>> PutAsync([FromRoute] int id, [FromBody] SponsorShipModel model)
        {
            SponsorShip sponsorShip = await _repository.GetByIdAsync(id);

            if (sponsorShip == null)
            {
                return NotFound();
            }

            sponsorShip.Name = model.Name;

            SponsorShipDto dto = new SponsorShipDto
            {
                Id = sponsorShip.Id,
                Name = sponsorShip.Name,
            };

            _repository.Update(sponsorShip);
            await _unitOfWork.CommitAsync();

            return Ok(dto);
        }
    }
}