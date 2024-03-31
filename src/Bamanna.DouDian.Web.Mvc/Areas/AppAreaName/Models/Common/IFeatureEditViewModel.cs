using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Bamanna.DouDian.Editions.Dto;

namespace Bamanna.DouDian.Web.Areas.AppAreaName.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}