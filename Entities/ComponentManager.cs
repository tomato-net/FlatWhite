using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
            int componentTypeId = GetComponentTypeId(typeof(T));

            if (_componentMappers.ContainsKey(componentTypeId) && _componentMappers[componentTypeId] != null)
                return _componentMappers[componentTypeId] as ComponentMapper<T>;

            return CreateMapperForType<T>(componentTypeId);
        }

        private int GetMapperId<T>()
        {
            if (_componentTypes.TryGetValue(typeof(T), out int id))
                return id;

            return -1;
        }

        public int GetComponentTypeId(Type type)
        {
            if (_componentTypes.TryGetValue(type, out int id))
                return id;

            id = _componentTypes.Count;
            _componentTypes.Add(type, id);
            return id;
        }

        public BitVector32 CreateComponentBits(int entityId)
        {
            BitVector32 componentBits = new BitVector32();
            int mask = BitVector32.CreateMask();

            for (var componentId = 0; componentId < _componentMappers.Count; componentId++)
            {
                componentBits[mask] = _componentMappers[componentId]?.Has(entityId) ?? false;
                mask = BitVector32.CreateMask(mask);
            }

            return componentBits;
        }
    }
}
