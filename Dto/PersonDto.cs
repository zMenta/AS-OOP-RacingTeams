
using AS_OOP_RacingTeams.Domain.Entities;

namespace AS_OOP_RacingTeams.Dto
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Birth_year { get; set; }
        public Job job { get; set; }

    }
}