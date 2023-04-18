using System.ComponentModel.DataAnnotations;

namespace back_end.Models
{
    public class SignUpModel
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        public string confirmPassword { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
    }
}
