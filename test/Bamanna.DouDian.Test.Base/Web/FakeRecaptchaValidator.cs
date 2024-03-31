using System.Threading.Tasks;
using Bamanna.DouDian.Security.Recaptcha;

namespace Bamanna.DouDian.Test.Base.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
