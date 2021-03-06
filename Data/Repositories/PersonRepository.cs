using AS_OOP_RacingTeams.Data.Context;
using AS_OOP_RacingTeams.Domain.Entities;
using AS_OOP_RacingTeams.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AS_OOP_RacingTeams.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {

        private readonly DataContext _Context;

        public PersonRepository(DataContext context)
        {
            this._Context = context;
        }

        public bool Delete(int entityId)
        {
            Person Person = _Context.Persons.FirstOrDefault(i => i.Id == entityId);

            if (Person == null)
            {
                return false;
            }
            else
            {
                _Context.Persons.Remove(Person);
                return true;
            }
        }


        public async Task<IList<Person>> GetAllAsync()
        {
            return await _Context.Persons
            .Include(i => i.Job)
            .ToListAsync();
        }


        public void Save(Person entity)
        {
            _Context.Persons.Add(entity);
        }


        public void Update(Person entity)
        {
            _Context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<Person> GetByIdAsync(int entityId)
        {
            return await _Context.Persons
            .Include(i => i.Job)
            .FirstOrDefaultAsync(i => i.Id == entityId);
        }
    }
}