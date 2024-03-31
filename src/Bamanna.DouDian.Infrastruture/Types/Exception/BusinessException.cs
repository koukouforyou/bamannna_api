using System;
using System.Collections.Generic;
using System.Text;



namespace Bamanna.DouDian.Infrastructure
{
    [Serializable]
	public class BusinessException : BaseException
    {
        public BusinessException()
        { }

        //一个异常消息参数和一个异常错误类。
        public BusinessException(string code, System.Exception innerException)
            : base(code, innerException)
        {

        }


        //一个异常编码参数和一个异常错误类。
        public BusinessException(string code)
            : base(code)
        {


        }

        public BusinessException(string errMsg,int exceptionLevel)
        {
            if (errMsg != string.Empty)
            {
                if (exceptionLevel == 1)
                {
                    
                }
            }
                
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override string GetMessage(string code)
        {
            string msg = base.GetMessage(code);
            if (string.IsNullOrEmpty(msg))
            {
                msg = "出现业务规则冲突";
            }

            return msg;
        }
    }
}
