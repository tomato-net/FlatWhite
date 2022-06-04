using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatWhite.Entities.Systems
{
    abstract class EntitySystem : ISystem
    {
        private EntityManager _entityManager;
        private IComponentMapperService _componentManager;
        private Aspect _aspect;
        private AspectBuilder _aspectBuilder;
        public List<int> ActiveEntities { 
            get
            {
                // TODO: Use event system to avoid having to compute
                List<int> activeEntities = new List<int>();
                foreach (Entity entity in _entityManager.Entities.Values)
                {
                    if (_aspect.IsInterested(_entityManager.GetComponentBits(entity.Id)))
                        activeEntities.Add(entity.Id);
                }

                return activeEntities;
            }
        }

        protected EntitySystem(AspectBuilder aspectBuilder)
        {
            _aspectBuilder = aspectBuilder;
        }

        public void Initialize(EntityManager entityManager, ComponentManager componentManager)
        {
            _entityManager = entityManager;
            _componentManager = componentManager;
            _aspect = _aspectBuilder.Build(componentManager);

            Initialize(componentManager);
        }

        public abstract void Initialize(IComponentMapperService mapperService);
    }
}
