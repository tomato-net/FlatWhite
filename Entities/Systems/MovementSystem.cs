using FlatWhite.Entities.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatWhite.Entities.Systems
{
    internal class MovementSystem: IUpdateSystem
    {
        private EntityManager _entityManager;
        private ComponentMapper<Position> _positionMapper;
        private ComponentMapper<Physics> _physicsMapper;
        public void Update(GameTime gameTime)
        {
            foreach (Entity entity in _entityManager.Entities.Values)
            {
                if (!_positionMapper.Has(entity.Id))
                    continue;

                if (!_physicsMapper.Has(entity.Id))
                    continue;

                Position pos = _positionMapper.Get(entity.Id);
                Physics physics = _physicsMapper.Get(entity.Id);

                Vector2 transform = new Vector2(physics.Speed);
                Vector2 position = pos.Vector + transform * (float)gameTime.ElapsedGameTime.TotalSeconds;
                pos.Vector = position;
            }
        }

        public void Initialize(EntityManager entityManager, IComponentMapperService componentMapperService)
        {
            _entityManager = entityManager;
            _positionMapper = componentMapperService.GetMapper<Position>();
            _physicsMapper = componentMapperService.GetMapper<Physics>();
        }
    }
}
