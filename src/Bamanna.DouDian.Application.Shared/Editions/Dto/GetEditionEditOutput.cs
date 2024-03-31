﻿using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Bamanna.DouDian.Editions.Dto
{
    public class GetEditionEditOutput
    {
        public EditionEditDto Edition { get; set; }

        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}