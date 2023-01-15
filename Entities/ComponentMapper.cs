using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatWhite.Entities
{
    public abstract class ComponentMapper
    {
        public int Id { get; init; }

        public abstract bool Has(int entityId);
        public abstract void Delete(int entityId);

    }

    internal class ComponentMapper<T>: ComponentMapper
        where T : class
    {
        private readonly Dictionary<int, T> _components = new Dictionary<int, T>();

        public void Add(int entityId, T component)
        {
            _components.Add(entityId, component);
        }

        public T Get(int entityId)
        {
            return _components[entityId];
        }

        public override bool Has(int entityId)
        {
            return _components.ContainsKey(entityId);
        }

        public override void Delete(int entityId)
        {
            _components[entityId] = null;
        }
    }
}
