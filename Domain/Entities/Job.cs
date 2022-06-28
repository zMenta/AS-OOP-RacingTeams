namespace AS_OOP_RacingTeams.Domain.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IList<Person>? Person { get; internal set; }
    }
}