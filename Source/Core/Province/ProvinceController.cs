using ecommerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using ecommerce.Core.Base;
using ecommerce.Core.Province.Dto;

namespace ecommerce.Core.Province
{ 
    [Route("api/province")]
    [ApiController]
    public class ProvinceController : BaseController<ProvinceEntity, ProvinceDto, CreateProvinceDto, UpdateProvinceDto>
    {
        public ProvinceController(ProvinceService service) : base(service, "Province")
        {
        }
    }
}
