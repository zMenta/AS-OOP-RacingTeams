using AS_OOP_RacingTeams.Data.Context;
using AS_OOP_RacingTeams.Domain.Entities;
using AS_OOP_RacingTeams.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AS_OOP_RacingTeams.Data.Repositories
{
    public class SponsorShipRepository : ISponsorShipRepository
    {
        private readonly DataContext _Context;

        public SponsorShipRepository(DataContext context)
        {
            this._Context = context;
        }
        public bool Delete(int entityId)
        {
            var sponsorship = _Context.SponsorShips.FirstOrDefault(i => i.Id == entityId);

            if (sponsorship == null)
            {
                return false;
            }
            else
            {
                _Context.SponsorShips.Remove(sponsorship);
                return true;
            }
        }

        public async Task<IList<SponsorShip>> GetAllAsync()
        {
            return await _Context.SponsorShips.ToListAsync();
        }

        public async Task<SponsorShip> GetByIdAsync(int entityId)
        {
            return await _Context.SponsorShips.FirstOrDefaultAsync(i => i.Id == entityId);
        }

        public void Save(SponsorShip entity)
        {

            _Context.SponsorShips.Add(entity);
        }

        public void Update(SponsorShip entity)
        {
            _Context.Entry(entity).State = EntityState.Modified;
        }
    }
}