using FlatWhite.Entities.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatWhite.Entities.Systems
{
    internal class MovementSystem: EntitySystem, IUpdateSystem
    {
        private ComponentMapper<Transform2> _positionMapper;
        private ComponentMapper<Physics> _physicsMapper;

        public MovementSystem(): base(Aspect.All(typeof(Transform2), typeof(Transform2))) { }

        public void Update(GameTime gameTime)
        {
            foreach (var entityId in ActiveEntities)
            {
                Transform2 pos = _positionMapper.Get(entityId);
                Physics physics = _physicsMapper.Get(entityId);

                Vector2 transform = new Vector2(physics.Speed);
                Vector2 position = pos.Vector + transform * (float)gameTime.ElapsedGameTime.TotalSeconds;
                pos.Vector = position;
            }
        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            _positionMapper = mapperService.GetMapper<Transform2>();
            _physicsMapper = mapperService.GetMapper<Physics>();
        }
    }
}
