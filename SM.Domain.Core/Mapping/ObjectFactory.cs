using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Domain.Core.Mapping
{
    public class ObjectFactory : IObjectFactory
    {
        private readonly IMapper _mapper;

        public ObjectFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public dynamic CreateConcreteObject(object obj)
        {
            var type = obj.GetType();
            dynamic result = _mapper.Map(obj, type, type);
            return result;
        }
    }
}
