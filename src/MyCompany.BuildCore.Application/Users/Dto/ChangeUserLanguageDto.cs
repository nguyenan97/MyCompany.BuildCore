using System.ComponentModel.DataAnnotations;

namespace MyCompany.BuildCore.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}