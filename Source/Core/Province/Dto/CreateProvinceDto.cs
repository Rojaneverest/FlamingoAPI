using System.ComponentModel.DataAnnotations;

namespace ecommerce.Core.Province.Dto
{
    public class CreateProvinceDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}

