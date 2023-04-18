using System.ComponentModel.DataAnnotations;

namespace back_end.Models
{
    public class ChangePasswordModel
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string oldPassword { get; set; }
        [Required]
        public string newPassword { get; set; }
    }
}
