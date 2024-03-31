using System.Threading.Tasks;
using Bamanna.DouDian.Sessions.Dto;

namespace Bamanna.DouDian.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
