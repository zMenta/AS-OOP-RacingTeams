using AS_OOP_RacingTeams.Domain.Entities;
using AS_OOP_RacingTeams.Dto.DtoRelations;

namespace AS_OOP_RacingTeams.Dto
{
    public class SponsorShipDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Teste { get; set; }
        public List<TeamRelationsDto> Teams { get; set; }
    }
}