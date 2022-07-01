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
        public async Task<ActionResult<List<SponsorShip>>> GetAllAsync()
        {
            return Ok(await _repository.GetAllAsync());
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<SponsorShip>> GetByIdAsync([FromRoute] int id)
        {
            SponsorShip sponsorShip = await _repository.GetByIdAsync(id);

            if (sponsorShip == null)
            {
                return NotFound();
            }

            return Ok(sponsorShip);
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
        public async Task<ActionResult<SponsorShip>> PutAsync([FromRoute] int id, [FromBody] SponsorShipModel model)
        {
            SponsorShip sponsorShip = await _repository.GetByIdAsync(id);

            if (sponsorShip == null)
            {
                return NotFound();
            }

            sponsorShip.Name = model.Name;
            _repository.Update(sponsorShip);
            await _unitOfWork.CommitAsync();

            return Ok(sponsorShip);
        }
    }
}