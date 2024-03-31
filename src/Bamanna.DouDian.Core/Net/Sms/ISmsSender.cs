using System.Threading.Tasks;

namespace Bamanna.DouDian.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}