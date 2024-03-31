using Bamanna.DouDian.Dto;

namespace Bamanna.DouDian.Organizations.Dto
{
    public class FindOrganizationUnitRolesInput : PagedAndFilteredInputDto
    {
        public long OrganizationUnitId { get; set; }
    }
}