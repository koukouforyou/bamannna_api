using Bamanna.DouDian.Dto;

namespace Bamanna.DouDian.Common.Dto
{
    public class FindUsersInput : PagedAndFilteredInputDto
    {
        public int? TenantId { get; set; }
    }
}