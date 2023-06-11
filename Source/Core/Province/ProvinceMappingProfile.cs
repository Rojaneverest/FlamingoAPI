using ecommerce.Data.Entity;
using ecommerce.Core.Province.Dto;
using ecommerce.Core.Base;

namespace ecommerce.Core.Province
{
    public class ProvinceProfile : BaseMappingProfile<ProvinceEntity, ProvinceDto, CreateProvinceDto, UpdateProvinceDto>
    {
        public ProvinceProfile()
        {
        }
    }
}

