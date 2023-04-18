using back_end.Models;
using Microsoft.AspNetCore.Identity;

namespace back_end.Repository
{
    public interface IUserRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        public Task<string> SignInAsync(SignInModel signInModel);
        public Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel changePasswordModel);
    }
}
