using System;
using Abp.AutoMapper;
using Bamanna.DouDian.Sessions.Dto;

namespace Bamanna.DouDian.Models.Common
{
    [AutoMapFrom(typeof(ApplicationInfoDto)),
     AutoMapTo(typeof(ApplicationInfoDto))]
    public class ApplicationInfoPersistanceModel
    {
        public string Version { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}