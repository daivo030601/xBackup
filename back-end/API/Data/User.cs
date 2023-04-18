using Microsoft.AspNetCore.Identity;

namespace back_end.Data
{
    public class User : IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
