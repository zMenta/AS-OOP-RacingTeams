using AS_OOP_RacingTeams.Data.Context;
using AS_OOP_RacingTeams.Domain.Entities;
using AS_OOP_RacingTeams.Domain.Interfaces;

namespace AS_OOP_RacingTeams.Data.Repositories
{
    public class JobRepository : IJobRepository
    {

        private readonly DataContext _Context;

        public JobRepository(DataContext context)
        {
            this._Context = context;
        }

        public void Delete(Job entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Job>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Job> GetByIdAsync(int id)
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