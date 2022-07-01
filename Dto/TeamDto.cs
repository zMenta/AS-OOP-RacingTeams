using AS_OOP_RacingTeams.Domain.Entities;

namespace AS_OOP_RacingTeams.Dto
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cnpj { get; set; }
        public List<SponsorShip> SponsorShips { get; set; }
        public List<Person> Person { get; set; }
    }
}