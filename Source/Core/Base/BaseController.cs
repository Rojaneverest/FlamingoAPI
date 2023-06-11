using ecommerce.Data.Entity;
using ecommerce.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Core.Base
{
    public class BaseController<Entity, DTO, CDTO, UDTO> : ControllerBase where Entity : class
    {
        private readonly BaseService<Entity, DTO, CDTO, UDTO> _service;
        private readonly string _moduleName;

        public BaseController(BaseService<Entity, DTO, CDTO, UDTO> service, string moduleName)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _moduleName = moduleName;
        }

        [HttpGet]
        public async Task<ServerResponse<ICollection<DTO>>> GetAll()
        {
            try
            {
                return ServerResponse<ICollection<DTO>>.Success(Response, await _service.GetAll(), _moduleName + "s fetched successfully.");

            }
            catch (Exception e)
            {
                return ServerResponse<ICollection<DTO>>.Error(Response, e);
            }
        }

        [HttpGet("{id}")]
        public async Task<ServerResponse<DTO>> GetById(string id)
        {
            try
            {
                return ServerResponse<DTO>.Success(Response, await _service.GetById(id), _moduleName + $" with id ({id}) fetched successfully.");
            }
            catch (Exception e)
            {
                return ServerResponse<DTO>.Error(Response, e);
            }
        }

        [HttpPost]
        public async Task<ServerResponse<DTO>> Create(CDTO cDto)
        {
            try
            {

                return ServerResponse<DTO>.Success(Response, await _service.Create(cDto), _moduleName + $" created successfully.");
            }
            catch (Exception e)
            {
                return ServerResponse<DTO>.Error(Response, e);
            }
        }

        [HttpPut("{id}")]
        public async Task<ServerResponse<DTO>> Update(string id, UDTO uDto)
        {
            try
            {
                return ServerResponse<DTO>.Success(Response, await _service.Update(id, uDto), _moduleName + $" updated successfully.");
            }
            catch (Exception e)
            {
                return ServerResponse<DTO>.Error(Response, e);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ServerResponse<DTO>> Delete(string id)
        {
            try
            {
                return ServerResponse<DTO>.Success(Response, await _service.Delete(id), _moduleName + $" deleted successfully.");
            }
            catch (Exception e)
            {
                return ServerResponse<DTO>.Error(Response, e);
            }
        }
    }
}
