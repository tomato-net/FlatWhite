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

        public void Initialize(EntityManager entityManager, IComponentMapperService componentManager)
        {
            _entityManager = entityManager;
            _componentManager = componentManager;
        }
    }
}
