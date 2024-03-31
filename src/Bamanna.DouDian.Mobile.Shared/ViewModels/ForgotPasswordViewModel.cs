using System.Threading.Tasks;
using System.Windows.Input;
using Abp.MultiTenancy;
using Acr.UserDialogs;
using Bamanna.DouDian.DouDianClient;
using Bamanna.DouDian.Authorization.Accounts;
using Bamanna.DouDian.Authorization.Accounts.Dto;
using Bamanna.DouDian.Commands;
using Bamanna.DouDian.Core.Threading;
using Bamanna.DouDian.Localization;
using Bamanna.DouDian.ViewModels.Base;
using Bamanna.DouDian.Views;

namespace Bamanna.DouDian.ViewModels
{
    public class ForgotPasswordViewModel : XamarinViewModel
    {
        public ICommand SendForgotPasswordCommand => HttpRequestCommand.Create(SendForgotPasswordAsync);

        private readonly IAccountAppService _accountAppService;
        private bool _isForgotPasswordEnabled;

        public ForgotPasswordViewModel(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }

        private string _emailAddress;
        public string EmailAddress
        {
            get => _emailAddress;
            set
            {
                _emailAddress = value;
                SetEmailActivationButtonEnabled();
                RaisePropertyChanged(() => EmailAddress);
            }
        }

        public bool IsForgotPasswordEnabled
        {
            get => _isForgotPasswordEnabled;
            set
            {
                _isForgotPasswordEnabled = value;
                RaisePropertyChanged(() => IsForgotPasswordEnabled);
            }
        }

        public void SetEmailActivationButtonEnabled()
        {
            IsForgotPasswordEnabled = !string.IsNullOrWhiteSpace(EmailAddress);
        }

        private async Task SendForgotPasswordAsync()
        {
            await SetBusyAsync(async () =>
            {
                await WebRequestExecuter.Execute(
                    async () =>
                    await _accountAppService.SendPasswordResetCode(new SendPasswordResetCodeInput { EmailAddress = EmailAddress }),
                    PasswordResetMailSentAsync
                );
            });
        }

        private async Task PasswordResetMailSentAsync()
        {
            await UserDialogs.Instance.AlertAsync(L.Localize("PasswordResetMailSentMessage"), L.Localize("MailSent"), L.Localize("Ok"));

            await NavigationService.SetMainPage<LoginView>(clearNavigationHistory: true);
        }
    }
}
