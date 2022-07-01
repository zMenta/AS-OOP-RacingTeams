using System.Text.Json.Serialization;

namespace AS_OOP_RacingTeams.Domain.Entities
{
    public class SponsorShip
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public IList<Team> Teams { get; set; }
    }
}