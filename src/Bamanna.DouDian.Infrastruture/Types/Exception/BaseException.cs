using System;
using System.Collections.Generic;
using System.Text;

namespace Bamanna.DouDian.Infrastructure
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2240:ImplementISerializableCorrectly"), Serializable]
    public class BaseException : ApplicationException
    {
        public BaseException()
        { }

        //�쳣����
        private string m_code;

        // �쳣����
        public virtual string Code
        {
            get
            {
                return m_code;
            }
            set
            {
                m_code = value;
            }
        }

        private string m_Message;
        public override string Message
        {
            get
            {
                return m_Message;
            }
        }

        //һ���쳣��Ϣ������һ���쳣�����ࡣ
        public BaseException(System.Exception innerMessage)
            : base("", innerMessage)
        {


        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaseException(string code, System.Exception innerException)
            : base("", innerException)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentException("�쳣����code����Ϊ��");
            }

            m_code = code;
            m_Message = GetMessage(code);

        }

        public BaseException(string code)
            : this(code, null)
        {



        }


        protected virtual string GetMessage(string code)
        {
            //if (ExceptionRecs.ResourceManager != null)
            //{
            //    string errorMsg = ExceptionRecs.ResourceManager.GetString(code);
            //    if (string.IsNullOrEmpty(errorMsg)) return code;
            //    return errorMsg;
            //}

            if (InnerException != null)
            {
                return InnerException.Message;
            }

            //return "����{0}�쳣!";
            return code;
        }

        //���ô˷������Եõ��쳣��Ϣҳ����ļ�·��
        public virtual string GetMessageFile()
        {
            //IDictionary idFilePath = (IDictionary)ConfigurationSettings.GetConfig("FilePath");
            //string filePath = (string)idFilePath["settingPath"];
            string filePath = "asdfasd";
            return filePath;
        }


    }
}
