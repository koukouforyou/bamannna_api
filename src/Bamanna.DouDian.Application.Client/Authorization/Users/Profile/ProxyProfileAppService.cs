using System;
using System.Threading.Tasks;
using Bamanna.DouDian.Authorization.Users.Dto;
using Bamanna.DouDian.Authorization.Users.Profile.Dto;

namespace Bamanna.DouDian.Authorization.Users.Profile
{
    public class ProxyProfileAppService : ProxyAppServiceBase, IProfileAppService
    {
        public async Task<CurrentUserProfileEditDto> GetCurrentUserProfileForEdit()
        {
            return await DouDianClient.GetAsync<CurrentUserProfileEditDto>(GetEndpoint(nameof(GetCurrentUserProfileForEdit)));
        }

        public async Task UpdateCurrentUserProfile(CurrentUserProfileEditDto input)
        {
            await DouDianClient.PutAsync(GetEndpoint(nameof(UpdateCurrentUserProfile)), input);
        }

        public async Task ChangePassword(ChangePasswordInput input)
        {
            await DouDianClient.PostAsync(GetEndpoint(nameof(ChangePassword)), input);
        }

        public async Task UpdateProfilePicture(UpdateProfilePictureInput input)
        {
            await DouDianClient.PutAsync(GetEndpoint(nameof(UpdateProfilePicture)), input);
        }

        public async Task<GetPasswordComplexitySettingOutput> GetPasswordComplexitySetting()
        {
            return await DouDianClient.GetAsync<GetPasswordComplexitySettingOutput>(GetEndpoint(nameof(GetPasswordComplexitySetting)));
        }

        public async Task<GetProfilePictureOutput> GetProfilePicture()
        {
            return await DouDianClient.GetAsync<GetProfilePictureOutput>(GetEndpoint(nameof(GetProfilePicture)));
        }

        public async Task<GetProfilePictureOutput> GetProfilePictureById(Guid profilePictureId)
        {
            return await DouDianClient.GetAsync<GetProfilePictureOutput>(GetEndpoint(nameof(GetProfilePictureById)),
                new { profilePictureId = profilePictureId });
        }

        public async Task<GetProfilePictureOutput> GetFriendProfilePictureById(GetFriendProfilePictureByIdInput input)
        {
            return await DouDianClient.GetAsync<GetProfilePictureOutput>(GetEndpoint(nameof(GetFriendProfilePictureById)), input);
        }

        public async Task ChangeLanguage(ChangeUserLanguageDto input)
        {
            await DouDianClient.PostAsync(GetEndpoint(nameof(ChangeLanguage)), input);
        }

        public async Task<UpdateGoogleAuthenticatorKeyOutput> UpdateGoogleAuthenticatorKey()
        {
            return await DouDianClient.PutAsync<UpdateGoogleAuthenticatorKeyOutput>(GetEndpoint(nameof(UpdateGoogleAuthenticatorKey)));
        }

        public async Task SendVerificationSms(SendVerificationSmsInputDto input)
        {
            await DouDianClient.PostAsync(GetEndpoint(nameof(SendVerificationSms)), input);
        }

        public async Task VerifySmsCode(VerifySmsCodeInputDto input)
        {
            await DouDianClient.PostAsync(GetEndpoint(nameof(VerifySmsCode)));
        }

        public async Task PrepareCollectedData()
        {
            await DouDianClient.PostAsync(GetEndpoint(nameof(PrepareCollectedData)));
        }
    }
}