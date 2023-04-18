using back_end.Models;
using back_end.Repository;
using back_end.Response;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost("login")]
        public async Task<ResponseModel> loginUser(SignInModel model)
        {
            return new ResponseModel(System.Net.HttpStatusCode.OK, "Success!", await userRepository.SignInAsync(model));
        }
        [HttpPost("register")]
        public async Task<ResponseModel> registerUser(SignUpModel model)
        {
            return new ResponseModel(System.Net.HttpStatusCode.OK, "Success!", await userRepository.SignUpAsync(model));
        }
        [HttpPost("change-password")]
        public async Task<ResponseModel> changePassword(ChangePasswordModel model)
        {
            return new ResponseModel(System.Net.HttpStatusCode.OK, "Success!", await userRepository.ChangePasswordAsync(model));
        }
    }
}
