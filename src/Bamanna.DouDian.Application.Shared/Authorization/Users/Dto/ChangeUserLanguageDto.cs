using System.ComponentModel.DataAnnotations;

namespace Bamanna.DouDian.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
