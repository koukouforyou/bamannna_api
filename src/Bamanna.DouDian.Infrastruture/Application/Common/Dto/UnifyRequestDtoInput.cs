using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.Infrasturcture.Modules.Common.Dto
{
    /// <summary>
    /// 通用Input
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public class UnifyRequestDtoInput<TPrimaryKey> : UnifyEntityDtoInputBase<TPrimaryKey>
    {
    }


    /// <summary>
    /// 通用Input
    /// </summary>
    public class UnifyRequestDtoInput : UnifyRequestDtoInput<Guid>
    {
    }
}
