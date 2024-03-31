using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.Infrasturcture.Modules
{
    /// <summary>
    /// 错误信息类
    /// </summary>
    public class UnifyErrorInfo
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public RestfulDouDianStatusCodes Code { get; set; }
        /// <summary>
        /// 系统（业务）异常信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 后台异常信息
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// 验证未通过信息
        /// </summary>
        public string ValidationErrors { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnifyErrorInfo"/> class.
        /// </summary>
        public UnifyErrorInfo() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnifyErrorInfo"/> class.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="message">The message.</param>
        /// <param name="details">The details.</param>
        /// <param name="validationErrors">The validation errors.</param>
        public UnifyErrorInfo(RestfulDouDianStatusCodes errorCode, string message, string details, string validationErrors)
        {
            Code = errorCode;
            Message = message;
            Details = details;
            ValidationErrors = validationErrors;
        }

    }
}
