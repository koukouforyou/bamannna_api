using System.Globalization;

namespace Bamanna.DouDian.Localization
{
    public interface IApplicationCulturesProvider
    {
        CultureInfo[] GetAllCultures();
    }
}