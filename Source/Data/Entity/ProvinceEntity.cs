using System.ComponentModel.DataAnnotations;

namespace ecommerce.Data.Entity
{
    public class ProvinceEntity:BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<UserEntity>? Users { get; set; }
    }
}
