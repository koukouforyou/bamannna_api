using System.Threading.Tasks;

namespace Bamanna.DouDian.Security
{
    public interface IPasswordComplexitySettingStore
    {
        Task<PasswordComplexitySetting> GetSettingsAsync();
    }
}
