using AS_OOP_RacingTeams.Domain.Entities;
using AS_OOP_RacingTeams.Domain.Interfaces;

namespace AS_OOP_RacingTeams.Data.Repositories
{
    public class PersonRepository : IJobRepository
    {
        public bool Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Job>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Job> GetByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Save(Job entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Job entity)
        {
            throw new NotImplementedException();
        }
    }
}