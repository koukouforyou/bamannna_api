using System;
using System.Collections.Generic;
using System.Text;

namespace Bamanna.DouDian.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class SwaggerIgnoreAttribute : Attribute
    {

    }
}
