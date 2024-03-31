using Bamanna.DouDian.Dto;

namespace Bamanna.DouDian.Organizations.Dto
{
    public class FindOrganizationUnitUsersInput : PagedAndFilteredInputDto
    {
        public long OrganizationUnitId { get; set; }
    }
}
