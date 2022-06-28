namespace AS_OOP_RacingTeams.Domain.Entities
{
    public class SponsorShip
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IList<Team>? Teams { get; set; }
    }
}