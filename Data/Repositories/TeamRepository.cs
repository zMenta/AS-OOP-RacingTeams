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
            var team = _Context.Teams.FirstOrDefault(i => i.Id == entityId);

            if (team == null)
            {
                return false;
            }
            else
            {
                _Context.Teams.Remove(team);
                return true;
            }
        }

        public async Task<IList<Team>> GetAllAsync()
        {
            return await _Context.Teams
            .Include(x => x.Persons)
            .Include(x => x.SponsorShips)
            .ToListAsync();
        }

        public async Task<Team> GetByIdAsync(int entityId)
        {
            return await _Context.Teams
            .Include(x => x.Persons)
            .Include(x => x.SponsorShips)
            .FirstOrDefaultAsync(i => i.Id == entityId);
        }

        public void Save(Team entity)
        {
            _Context.Teams.Add(entity);
        }

        public void Update(Team entity)
        {
            _Context.Entry(entity).State = EntityState.Modified;
        }
    }
}