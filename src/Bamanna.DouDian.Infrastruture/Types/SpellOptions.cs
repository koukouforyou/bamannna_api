

namespace Bamanna.DouDian.Infrastructure.Types
{
    /// <summary>
    /// �ṩ��������ת��ѡ���ö��ֵ��
    /// </summary>
    /// <value>
    /// <code>FirstLetterOnly</code>
    /// ֻת��ƴ������ĸ��Ĭ��ת��ȫ��
    /// </value>
    /// <value>
    /// <code>TranslateUnknowWordToInterrogation</code>
    /// ת��δ֪����Ϊ�ʺţ�Ĭ�ϲ�ת��
    /// </value>
    /// <value>
    /// <code>EnableUnicodeLetter</code>
    /// �������ĸ���������ַ���Ĭ�ϲ�����
    /// </value>
    [System.Flags]
    public enum SpellOptions
    {
        FirstLetterOnly = 1,													//ֻת��ƴ������ĸ��Ĭ��ת��ȫ��
        TranslateUnknowWordToInterrogation = 1 << 1,		//ת��δ֪����Ϊ�ʺţ�Ĭ�ϲ�ת��
        EnableUnicodeLetter = 1 << 2,								//�������ĸ���������ַ���Ĭ�ϲ�����
    }

}
