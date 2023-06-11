using ecommerce.Data.Entity;
using ecommerce.Core.User.Dto;
using ecommerce.Core.Base;

namespace ecommerce.Core.User
{
    public class UserProfile : BaseMappingProfile<UserEntity, UserDto, dynamic, dynamic>
    {
        public UserProfile()
        {
        }
    }
}

