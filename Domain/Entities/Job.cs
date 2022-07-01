using System.Text.Json.Serialization;

namespace AS_OOP_RacingTeams.Domain.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public IList<Person> Person { get; internal set; }
    }
}