using System.Threading.Tasks;
using Bamanna.DouDian.Authorization.Accounts.Dto;

namespace Bamanna.DouDian.Authorization.Accounts
{
    public class ProxyAccountAppService : ProxyAppServiceBase, IAccountAppService
    {
        public async Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input)
        {
            return await DouDianClient.PostAnonymousAsync<IsTenantAvailableOutput>(GetEndpoint(nameof(IsTenantAvailable)), input);
        }

        public async Task<int?> ResolveTenantId(ResolveTenantIdInput input)
        {
            return await DouDianClient.PostAnonymousAsync<int?>(GetEndpoint(nameof(ResolveTenantId)), input);
        }

        public async Task<RegisterOutput> Register(RegisterInput input)
        {
            return await DouDianClient.PostAnonymousAsync<RegisterOutput>(GetEndpoint(nameof(Register)), input);
        }

        public async Task SendPasswordResetCode(SendPasswordResetCodeInput input)
        {
            await DouDianClient.PostAnonymousAsync(GetEndpoint(nameof(SendPasswordResetCode)), input);
        }

        public async Task<ResetPasswordOutput> ResetPassword(ResetPasswordInput input)
        {
            return await DouDianClient.PostAnonymousAsync<ResetPasswordOutput>(GetEndpoint(nameof(ResetPassword)), input);
        }

        public async Task SendEmailActivationLink(SendEmailActivationLinkInput input)
        {
            await DouDianClient.PostAnonymousAsync(GetEndpoint(nameof(SendEmailActivationLink)), input);
        }

        public async Task ActivateEmail(ActivateEmailInput input)
        {
            await DouDianClient.PostAnonymousAsync(GetEndpoint(nameof(ActivateEmail)), input);
        }

        public async Task<ImpersonateOutput> Impersonate(ImpersonateInput input)
        {
            return await DouDianClient.PostAsync<ImpersonateOutput>(GetEndpoint(nameof(Impersonate)), input);
        }

        public async Task<ImpersonateOutput> BackToImpersonator()
        {
            return await DouDianClient.PostAnonymousAsync<ImpersonateOutput>(GetEndpoint(nameof(BackToImpersonator)));
        }

        public async Task<SwitchToLinkedAccountOutput> SwitchToLinkedAccount(SwitchToLinkedAccountInput input)
        {
            return await DouDianClient.PostAnonymousAsync<SwitchToLinkedAccountOutput>(GetEndpoint(nameof(SwitchToLinkedAccount)));
        }
    }
}