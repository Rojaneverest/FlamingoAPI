using Microsoft.AspNetCore.Identity;

namespace ecommerce.Data.Entity
{
    public class UserEntity : IdentityUser, IBaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        string IBaseEntity.Id { get; set; } = Guid.NewGuid().ToString();
        public string? ProvinceId { get; set; }
        public virtual ProvinceEntity? Province { get; set; }
        public virtual ICollection<TodoEntity> Todos { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
    }
}
