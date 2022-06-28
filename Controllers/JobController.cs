using AS_OOP_RacingTeams.Domain.Entities;
using AS_OOP_RacingTeams.Domain.Interfaces;
using AS_OOP_RacingTeams.Models;
using Microsoft.AspNetCore.Mvc;

namespace AS_OOP_RacingTeams.Controllers
{
    [Route("api/job")]
    public class JobController : ControllerBase
    {

        private readonly IJobRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public JobController(IJobRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<Job>>> GetAllAsync()
        {
            IList<Job> jobList = await _repository.GetAllAsync();
            return Ok(jobList);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Job>> GetByIdAsync([FromRoute] int id)
        {
            Job job = await _repository.GetByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }


        [HttpPost]
        public async Task<ActionResult<JobModel>> PostAsync([FromBody] JobModel model)
        {
            Job job = new Job
            {
                Name = model.Name
            };

            _repository.Save(job);
            await _unitOfWork.CommitAsync();

            return Ok(job);
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
            return Ok("Deleted Job Id: " + id);
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<JobModel>> PutAsync([FromRoute] int id,[FromBody] JobModel model)
        {
            Job job = await _repository.GetByIdAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            job.Name = model.Name;
            _repository.Update(job);
            await _unitOfWork.CommitAsync();

            return Ok(job);
        }

    }
}