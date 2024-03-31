using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using System.IO;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;

namespace Bamanna.DouDian.Api
{
    public class DouDianApiManager : ApiManagerBase, IDouDianApiManager
    {
        public DouDianApiManager()
        {
            ContentType = ContentType.Json;
            ConvertType = ConvertType.Camel;
            _settings = new Lazy<JsonSerializerSettings>(() =>
            {
                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
                };
                return settings;
            });
        }
    }
}
