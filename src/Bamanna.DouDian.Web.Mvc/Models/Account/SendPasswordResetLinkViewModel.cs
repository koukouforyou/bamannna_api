using System.ComponentModel.DataAnnotations;

namespace Bamanna.DouDian.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}