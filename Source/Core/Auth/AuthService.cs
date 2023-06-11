using Microsoft.AspNetCore.Identity;
using ecommerce.Data.Entity;
using ecommerce.Core.Auth.Dto;
using ecommerce.Core.User;
using ecommerce.Core.User.Dto;
using AutoMapper;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ecommerce.Shared.Helpers;

namespace ecommerce.Core.Auth
{
    public class AuthService
    {
        private readonly UserDao _userDao;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly JwtHelper _jwtHelper;

        public AuthService(JwtHelper jwtHelper, UserDao userDao, IMapper mapper, IConfiguration configuration)
        {
            _jwtHelper = jwtHelper;
            _userDao = userDao;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await this._userDao.GetByEmail(loginDto.Email);

            if (user == null || !(await this._userDao.CheckPassword(user, loginDto.Password)))
            {
                throw new BadHttpRequestException("Invalid credentials.");
            }

            return await this._jwtHelper.Sign(user);

        }

        public async Task<UserDto> SignUp(SignupDto signUpDto, string[] roles)
        {
            // Checking if user with email already exists
            var existingUser = await this._userDao.GetByEmail(signUpDto.Email);
            if (existingUser != null)
            {
                throw new BadHttpRequestException("User with the email already exists.");
            }

            // Creating user
            var newUser = new UserEntity
            {
                Email = signUpDto.Email,
                FirstName = signUpDto.FirstName,
                LastName = signUpDto.LastName,
                UserName = signUpDto.FirstName
            };
            var result = await this._userDao.Create(newUser, signUpDto.Password);

            if (!result.Succeeded)
            {

                throw new BadHttpRequestException(result.Errors.First().Description ?? "Registration failed.");
            }

            // Adding roles
            foreach (var role in roles)
            {
                await this._userDao.AddToRole(newUser, role);
            }

            var userDto = _mapper.Map<UserDto>(newUser);

            userDto.Roles = roles;

            return userDto;
        }
    }
}