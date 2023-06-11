using AutoMapper;
using ecommerce.Data.Entity;
using ecommerce.Core.Province.Dto;
using ecommerce.Core.Base;

namespace ecommerce.Core.Province
{
    public class ProvinceService : BaseService<ProvinceEntity, ProvinceDto, CreateProvinceDto, UpdateProvinceDto>
    {
        public ProvinceService(ProvinceDao dao, IMapper mapper) : base(dao, mapper, "Province")
        {
        }
    }
}
