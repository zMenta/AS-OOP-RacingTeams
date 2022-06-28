using AS_OOP_RacingTeams.Domain.Entities;
using AS_OOP_RacingTeams.Domain.Interfaces;
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
            var jobList = await _repository.GetAllAsync();
            return Ok(jobList);
        }
    }
}