namespace AS_OOP_RacingTeams.Domain.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cnpj { get; set; }
        public List<Person> Persons { get; set; }
        public List<SponsorShip> SponsorShips { get; set; }
    }
}