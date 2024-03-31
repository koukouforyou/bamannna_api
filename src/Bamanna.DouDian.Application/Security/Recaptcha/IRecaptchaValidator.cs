using System.Threading.Tasks;

namespace Bamanna.DouDian.Security.Recaptcha
{
    public interface IRecaptchaValidator
    {
        Task ValidateAsync(string captchaResponse);
    }
}