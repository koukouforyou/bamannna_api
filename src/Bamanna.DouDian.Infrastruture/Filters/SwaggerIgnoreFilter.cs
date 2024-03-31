using Bamanna.DouDian.Infrastructure.Attributes;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bamanna.DouDian.Infrastructure.Filters
{
    public class SwaggerIgnoreFilter: IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {

            var ignoreApis = context.ApiDescriptions.Where(wh => wh.ActionAttributes().Any(any => any is SwaggerIgnoreAttribute));
            if (ignoreApis != null)
            {
                foreach (var ignoreApi in ignoreApis)
                {
                    swaggerDoc.Paths.Remove("/" + ignoreApi.RelativePath);
                }
            }

        }
    }
}
