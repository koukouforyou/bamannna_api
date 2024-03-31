using System;
using System.Threading.Tasks;
using Flurl.Http.Content;
using Bamanna.DouDian.Authorization.Users.Profile.Dto;

namespace Bamanna.DouDian.Authorization.Users.Profile
{
    public class ProxyProfileControllerService : ProxyControllerBase
    {
        public async Task<UploadProfilePictureOutput> UploadProfilePicture(Action<CapturedMultipartContent> buildContent)
        {
            return await DouDianClient
                .PostMultipartAsync<UploadProfilePictureOutput>(GetEndpoint(nameof(UploadProfilePicture)), buildContent);
        }
    }
}