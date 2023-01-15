using FlatWhite.Entities.Systems;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatWhite.Entities
{
    internal class EntityManager: IUpdateSystem
    {
        private int _nextId = 0;
        public Dictionary<int, Entity> Entities { get; private set; } = new Dictionary<int, Entity>(); 
        private readonly ComponentManager _componentManager;
        private Dictionary<int, BitVector32> _entityComponentBits = new Dictionary<int, BitVector32>();
        private List<int> _addedEntities = new List<int>();

        public EntityManager(ComponentManager componentManager)
        {
            Entities = new Dictionary<int, Entity>();
            _componentManager = componentManager;
        }

        public virtual void Initialize(EntityManager entityManager, ComponentManager componentManager) { }

        public Entity CreateEntity()
        {
            Entity entity = new Entity(_componentManager) {  Id = ++_nextId };
            Entities.Add(entity.Id, entity);

            _addedEntities.Add(entity.Id);

            return entity;
        }

        public Entity GetEntity(int entityId)
        {
            return Entities[entityId];
        }

        public BitVector32 GetComponentBits(int entityId)
        {
            return _entityComponentBits[entityId];
        }

        public void Update(GameTime gameTime)
        {
            foreach (var entityId in _addedEntities)
                _entityComponentBits[entityId] = _componentManager.CreateComponentBits(entityId);

            _addedEntities.Clear();
        }
    }
}
