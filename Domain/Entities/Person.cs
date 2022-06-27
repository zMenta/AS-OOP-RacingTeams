namespace AS_OOP_RacingTeams.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Birth_year { get; set; }
        public Job Job { get; set; }

        public List<Team> Teams { get; set; }
    }
}