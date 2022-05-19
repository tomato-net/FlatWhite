using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatWhite.Entities
{
    internal class EntityManager
    {
        private int _nextId = 0;
        public Dictionary<int, Entity> Entities { get; private set; }
        private readonly ComponentManager _componentManager;

        public EntityManager(ComponentManager componentManager)
        {
            Entities = new Dictionary<int, Entity>();
            _componentManager = componentManager;
        }

        public Entity CreateEntity()
        {
            Entity entity = new Entity(_componentManager) {  Id = ++_nextId };
            Entities.Add(entity.Id, entity);

            return entity;
        }

        public Entity GetEntity(int entityId)
        {
            return Entities[entityId];
        }
    }
}
