using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Bamanna.DouDian.Dto;

namespace Bamanna.DouDian.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
