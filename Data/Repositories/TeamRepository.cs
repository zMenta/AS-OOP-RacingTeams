using AS_OOP_RacingTeams.Data.Context;
using AS_OOP_RacingTeams.Domain.Entities;
using AS_OOP_RacingTeams.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using AS_OOP_RacingTeams.Dto;

namespace AS_OOP_RacingTeams.Data.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly DataContext _Context;

        public TeamRepository(DataContext context)
        {
            this._Context = context;
        }

        public bool Delete(int entityId)
        {
            var team = _Context.Team.FirstOrDefault(i => i.Id == entityId);

            if (team == null)
            {
                return false;
            }
            else
            {
                _Context.Team.Remove(team);
                return true;
            }
        }

        public async Task<IList<Team>> GetAllAsync()
        {
            return await _Context.Team.ToListAsync();
        }

        public async Task<Team> GetByIdAsync(int entityId)
        {
           return await _Context.Team.FirstOrDefaultAsync(i => i.Id == entityId);
        }

        public void Save(Team entity)
        {
             _Context.Team.Add(entity);
        }

        public void Update(Team entity)
        {
            _Context.Entry(entity).State = EntityState.Modified;
        }
    }
}