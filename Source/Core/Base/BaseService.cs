using ecommerce.Data.Entity;
using AutoMapper;

namespace ecommerce.Core.Base
{
    public class BaseService<Entity, DTO, CDTO, UDTO> where Entity : class
    {
        protected readonly BaseDao<Entity> _dao;
        protected readonly IMapper _mapper;
        private readonly string _moduleName;

        public BaseService(BaseDao<Entity> dao, IMapper mapper, string moduleName)
        {
            _dao = dao ?? throw new ArgumentNullException(nameof(dao));
            _mapper = mapper;
            _moduleName = moduleName;
        }

        public virtual async Task<DTO> GetById(string id)
        {
            var entity = await _dao.GetById(id) ?? throw new BadHttpRequestException($"{_moduleName} not found");
            return _mapper.Map<DTO>(entity);
        }

        public async virtual Task<ICollection<DTO>> GetAll()
        {
            IQueryable<Entity> query = _dao.GetAll();
            ICollection<Entity> collection = query.ToList();
            return _mapper.Map<DTO[]>(collection);
        }

        public virtual async Task<DTO> Create(CDTO cDto)
        {
            return _mapper.Map<DTO>(await _dao.Create(_mapper.Map<Entity>(cDto)));
        }

        public virtual async Task<DTO> Update(string id, UDTO uDto)
        {
            return _mapper.Map<DTO>(await _dao.Update(id, _mapper.Map<Entity>(uDto)));

        }

        public virtual async Task<DTO> Delete(string id)
        {
            return _mapper.Map<DTO>(await _dao.Delete(id));
        }
    }

}
