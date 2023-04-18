using back_end.Data;
using back_end.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace back_end.Repository.Implement
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ApplicationDBContext context;
        private readonly IConfiguration configuration;

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDBContext context, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
            this.configuration = configuration;
        }

        public async Task<string> SignInAsync(SignInModel signInModel)
        {
            var authentication = await signInManager.PasswordSignInAsync(signInModel.email, signInModel.password, false, false);
            if (!authentication.Succeeded)
            {
                throw new BadHttpRequestException("Email or password is wrong!");
            }
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, signInModel.email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]));

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:ValidIssuer"],
                audience: configuration["Jwt:ValidAudience"],
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel signUpModel)
        {
            var user = new User()
            {
                Email = signUpModel.email,
                firstName = signUpModel.firstName,
                lastName = signUpModel.lastName,
                UserName = signUpModel.email
            };
            return await userManager.CreateAsync(user, signUpModel.password);
        }
        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel changePasswordModel)
        {
            var user = await userManager.FindByEmailAsync(changePasswordModel.email);
            var checkOldPasswordResult = userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, changePasswordModel.oldPassword);
            if(checkOldPasswordResult != PasswordVerificationResult.Success)
            {
                throw new BadHttpRequestException("Old password is wrong!");
            }
            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var result = await userManager.ResetPasswordAsync(user, token, changePasswordModel.newPassword);
            return result;
        }
    }
}
