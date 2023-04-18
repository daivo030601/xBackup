using System.ComponentModel.DataAnnotations;

namespace back_end.Models
{
    public class SignInModel
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
