namespace AS_OOP_RacingTeams.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        IJobRepository JobRepository { get; }
        IPersonRepository PersonRepository { get; }
        ISponsorShipRepository SponsorShipRepository { get; }
        ITeamRepository TeamRepository { get; }
    }
}