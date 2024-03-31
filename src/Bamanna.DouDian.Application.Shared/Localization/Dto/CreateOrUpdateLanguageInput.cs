using System.ComponentModel.DataAnnotations;

namespace Bamanna.DouDian.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}