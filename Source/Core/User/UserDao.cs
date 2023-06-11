using ecommerce.Data;
using ecommerce.Data.Entity;
using ecommerce.Core.Base;
using Microsoft.AspNetCore.Identity;
using ecommerce.Core.Auth.Dto;
using System.Data;

namespace ecommerce.Core.User
{
    public class UserDao : BaseDao<UserEntity>
    {
        private readonly UserManager<UserEntity> _userManager;

        public UserDao(UserManager<UserEntity> usermanager, DatabaseContext context) : base(context)
        {
            _userManager = usermanager;
        }

        public async Task<UserEntity?> GetByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> CheckPassword(UserEntity user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<IdentityResult> Create(UserEntity user, string password)
        {
            return await this._userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> AddToRole(UserEntity user, string role)
        {
            return await this._userManager.AddToRoleAsync(user, role);
        }
    }
}
