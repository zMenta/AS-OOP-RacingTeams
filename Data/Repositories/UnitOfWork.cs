using AS_OOP_RacingTeams.Data.Context;
using AS_OOP_RacingTeams.Domain.Interfaces;

namespace AS_OOP_RacingTeams.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DataContext _Context;

        public UnitOfWork(DataContext context)
        {
            this._Context = context;
        }

        public async Task CommitAsync()
        {
            await _Context.SaveChangesAsync();
        }

        


        private IJobRepository _JobRepository;
        private ISponsorShipRepository _SponsorShipRepository;

        public IJobRepository JobRepository
        {
            get { return _JobRepository ??= new JobRepository(_Context);}
        }
        public ISponsorShipRepository SponsorShipRepository
        {
            get { return _SponsorShipRepository ??= new SponsorShipRepository(_Context);}
        }
        

    }
}