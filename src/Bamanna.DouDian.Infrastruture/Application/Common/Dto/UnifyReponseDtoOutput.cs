using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.Infrasturcture.Modules.Common.Dto
{
    /// <summary>
    /// Unify.Application层通用返回封装类（因最新版本ABP已经支持,后续将会弃用）
    /// </summary>
    /// <typeparam name="ReponseDto"></typeparam>
    [Obsolete("因最新版本ABP已经支持(0.10.0.0版本后),后续将会弃用")]
    public class UnifyReponseDtoOutput<ReponseDto> : UnifyEntityDtoOutputBase
    {
        /// <summary>
        /// 请求ID
        /// </summary>
        public virtual Guid RequestId { get; set; }

        /// <summary>
        /// Gets or sets the target URL.
        /// </summary>
        /// <value>The target URL.</value>
        public virtual string TargetUrl { get; set; }
        /// <summary>
        /// 返回的数据
        /// </summary>
        public virtual ReponseDto Result { get; set; }

        /// <summary>
        /// 失败时返回false
        /// </summary>
        public virtual bool Success { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public virtual UnifyErrorInfo Error { get; set; }

        /// <summary>
        /// 未授权时返回true
        /// </summary>
        public virtual bool UnAuthorizedRequest { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="UnifyReponseDtoOutput{ReponseDto}"/> class.
        /// </summary>
        public UnifyReponseDtoOutput()
        {
            Success = true;
        }

        /// <summary>
        /// 默认成功，请求Id为Guid.Empty
        /// </summary>
        /// <param name="response"></param>
        public UnifyReponseDtoOutput(ReponseDto response) : this(response, Guid.Empty, true)
        {
        }

        /// <summary>
        /// 默认成功
        /// </summary>
        /// <param name="response"></param>
        /// <param name="input"></param>
        public UnifyReponseDtoOutput(ReponseDto response, UnifyEntityDtoInputBase input) : this(response, input.RequestId.Value, true)
        {

        }

        /// <summary>
        /// 默认成功
        /// </summary>
        /// <param name="response"></param>
        /// <param name="requestId"></param>
        public UnifyReponseDtoOutput(ReponseDto response, Guid requestId) : this(response, requestId, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnifyReponseDtoOutput{ReponseDto}"/> class.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="input">The input.</param>
        /// <param name="success">if set to <c>true</c> [success].</param>
        public UnifyReponseDtoOutput(ReponseDto response, UnifyEntityDtoInputBase input, bool success) : this(response, input.RequestId.Value, success)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnifyReponseDtoOutput{ReponseDto}"/> class.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="success">if set to <c>true</c> [success].</param>
        public UnifyReponseDtoOutput(ReponseDto response, bool success) : this(response, Guid.Empty, success)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnifyReponseDtoOutput{ReponseDto}"/> class.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="success">if set to <c>true</c> [success].</param>
        public UnifyReponseDtoOutput(ReponseDto response, Guid requestId, bool success)
        {
            Result = response;
            Success = success;
            if (success)
            {
                UnAuthorizedRequest = false;
            }

            this.RequestId = requestId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnifyReponseDtoOutput{ReponseDto}"/> class.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="message">The message.</param>
        /// <param name="details">The details.</param>
        /// <param name="validationErrors">The validation errors.</param>
        public UnifyReponseDtoOutput(RestfulDouDianStatusCodes errorCode, string message, string details, string validationErrors)
        {
            this.Error = new UnifyErrorInfo(errorCode, message, details, validationErrors);
            this.Success = false;
            if (errorCode == RestfulDouDianStatusCodes.Unauthorized)
            {
                UnAuthorizedRequest = true;
            }
        }

    }
}
