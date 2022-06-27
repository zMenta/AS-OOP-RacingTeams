namespace AS_OOP_RacingTeams.Domain.Interfaces
{
    public interface IBaseRepository<Entity> where Entity : class
    {
        Task<Entity> GetByIdAsync(int id);
        Task<IList<Entity>> GetAllAsync();
        void Save(Entity entity);
        void Delete(Entity entity);
        void Update(Entity entity);

    }
}