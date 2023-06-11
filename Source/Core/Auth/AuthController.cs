using Microsoft.AspNetCore.Mvc;
using ecommerce.Shared.Helpers;
using ecommerce.Core.Auth.Dto;

namespace ecommerce.Core.Auth
{

    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly string _moduleName;
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _moduleName = "Auth";
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ServerResponse<dynamic>> Login(LoginDto loginDto)
        {
            try
            {
                var token = await _authService.Login(loginDto);
                return ServerResponse<dynamic>.Success(Response, token, "Logged in successfully.");

            }
            catch (Exception e)
            {
                return ServerResponse<dynamic>.Error(Response, e);
            }
        }

        [HttpPost("sign-up/user")]
        public async Task<ServerResponse<dynamic>> SignUpUser(SignupDto signUpDto)
        {
            try
            {
                var result = await _authService.SignUp(signUpDto, new string[] { "User" });
                return ServerResponse<dynamic>.Success(Response, result, "Signed up successfully.");

            }
            catch (Exception e)
            {
                return ServerResponse<dynamic>.Error(Response, e);
            }
        }
        [HttpPost("sign-up/admin")]
        public async Task<ServerResponse<dynamic>> SignUpAdmin(SignupDto signUpDto)
        {
            try
            {
                var result = await _authService.SignUp(signUpDto, new string[] { "Admin" });
                return ServerResponse<dynamic>.Success(Response, result, "Signed up successfully.");

            }
            catch (Exception e)
            {
                return ServerResponse<dynamic>.Error(Response, e);
            }
        }
        [HttpPost("sign-up/vendor")]
        public async Task<ServerResponse<dynamic>> SignUp(SignupDto signUpDto)
        {
            try
            {
                var result = await _authService.SignUp(signUpDto, new string[] { "Vendor" });
                return ServerResponse<dynamic>.Success(Response, result, "Signed up successfully.");

            }
            catch (Exception e)
            {
                return ServerResponse<dynamic>.Error(Response, e);
            }
        }
    }
}