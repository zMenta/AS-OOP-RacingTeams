namespace AS_OOP_RacingTeams.Domain.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cnpj { get; set; }
        public IList<Person> Persons { get; set; }
        public IList<SponsorShip> SponsorShips { get; set; } 

    }
}