using AS_OOP_RacingTeams.Domain.Entities;
using AS_OOP_RacingTeams.Dto.DtoRelations;

namespace AS_OOP_RacingTeams.Dto
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cnpj { get; set; }
        public List<SponsorRelationsDto> SponsorShips { get; set; }
        public List<PersonRelationsDto> Person { get; set; }
    }
}