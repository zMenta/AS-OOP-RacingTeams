namespace AS_OOP_RacingTeams.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        IJobRepository JobRepository { get; }
        ISponsorShipRepository SponsorShipRepository { get; }
        IPersonRepository PersonRepository { get; }
    
    }
}