using System;
using AutoMapper;

namespace ecommerce.Core.Base
{
    public class BaseMappingProfile<Entity, DTO, CDTO, UDTO> : Profile
    {
        public BaseMappingProfile()
        {
            CreateMap<Entity, DTO>();
            CreateMap<CDTO, Entity>();
            CreateMap<UDTO, Entity>();
        }
    }
}

