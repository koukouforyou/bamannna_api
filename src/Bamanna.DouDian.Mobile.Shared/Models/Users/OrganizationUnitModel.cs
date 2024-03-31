using Abp.AutoMapper;
using Bamanna.DouDian.Organizations.Dto;

namespace Bamanna.DouDian.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}