using System.ComponentModel.DataAnnotations;

namespace Bamanna.DouDian.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}