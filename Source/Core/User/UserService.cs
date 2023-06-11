using AutoMapper;
using ecommerce.Data.Entity;
using ecommerce.Core.Base;
using ecommerce.Core.User.Dto;

namespace ecommerce.Core.User
{
    public class UserService : BaseService<UserEntity, UserDto, dynamic, dynamic>
    {
        public UserService(UserDao dao, IMapper mapper) : base(dao, mapper, "User")
        {
        }
    }
}
