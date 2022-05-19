using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatWhite.Entities
{
    interface IComponentMapperService
    {
        public ComponentMapper<T> GetMapper<T>() where T : class;
    }

    internal class ComponentManager: IComponentMapperService
    {
        private readonly Dictionary<int, ComponentMapper> _componentMappers = new Dictionary<int, ComponentMapper>();
        private readonly Dictionary<Type, int> _componentTypes = new Dictionary<Type, int>();

        private ComponentMapper<T> CreateMapperForType<T>(int componentTypeId)
            where T : class
        {
            ComponentMapper<T> mapper = new ComponentMapper<T>() { Id = componentTypeId };
            _componentMappers[componentTypeId] = mapper;
            _componentTypes[typeof(T)] = mapper.Id;

            return mapper;
        }

        public ComponentMapper<T> GetMapper<T>()
            where T : class
        {
            int mapperId = GetMapperId<T>();

            if (_componentMappers.ContainsKey(mapperId))
                return _componentMappers[mapperId] as ComponentMapper<T>;

            return CreateMapperForType<T>(_componentTypes.Count);
        }

        private int GetMapperId<T>()
        {
            if (_componentTypes.TryGetValue(typeof(T), out int id))
                return id;

            return -1;
        }
    }
}
