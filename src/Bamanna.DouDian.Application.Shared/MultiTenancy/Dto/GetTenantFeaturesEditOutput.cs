using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Bamanna.DouDian.Editions.Dto;

namespace Bamanna.DouDian.MultiTenancy.Dto
{
    public class GetTenantFeaturesEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}