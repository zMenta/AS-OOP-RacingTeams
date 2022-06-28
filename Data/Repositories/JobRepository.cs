using AS_OOP_RacingTeams.Data.Context;
using AS_OOP_RacingTeams.Domain.Entities;
using AS_OOP_RacingTeams.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AS_OOP_RacingTeams.Data.Repositories
{
    public class JobRepository : IJobRepository
    {

        private readonly DataContext _Context;

        public JobRepository(DataContext context)
        {
            this._Context = context;
        }

        public bool Delete(int entityId)
        {
            var job = _Context.Jobs.FirstOrDefault(i => i.Id == entityId);

            if (job == null)
            {
                return false;
            }
            else
            {
                _Context.Jobs.Remove(job);
                return true;
            }
        }

        public async Task<IList<Job>> GetAllAsync()
        {
            return await _Context.Jobs.ToListAsync();
        }

        public async Task<Job> GetByIdAsync(int entityId)
        {
            return await _Context.Jobs.FirstOrDefaultAsync(i => i.Id == entityId);
        }

        public void Save(Job entity)
        {
            _Context.Jobs.Add(entity);
        }

        public void Update(Job entity)
        {
            _Context.Entry(entity).State = EntityState.Modified;
        }
    }
}