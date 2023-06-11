
using ecommerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using ecommerce.Core.Base;
using ecommerce.Core.User.Dto;

namespace ecommerce.Core.User
{
    [Route("api/user")]
    [ApiController]
    public class UserController : BaseController<UserEntity, UserDto, dynamic, dynamic>
    {
        public UserController(UserService service) : base(service, "User")
        {
        }
    }
}
