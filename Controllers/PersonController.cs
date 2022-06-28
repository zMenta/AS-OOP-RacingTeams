using AS_OOP_RacingTeams.Domain.Interfaces;

namespace AS_OOP_RacingTeams.Controllers
{
    public class PersonController
    {
        private readonly IPersonRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PersonController(IPersonRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
    }
}