using FlatWhite.Entities.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatWhite.Entities.Systems
{
    internal class RenderSystem : IDrawSystem
    {
        private readonly GraphicsDevice _graphicsDevice;
        private readonly SpriteBatch _spriteBatch;
        private EntityManager _entityManager;
        private ComponentMapper<Position> _positionMapper;
        private ComponentMapper<Components.Texture> _textureMapper;

        public RenderSystem(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
            _spriteBatch = new SpriteBatch(graphicsDevice);
        }

        public void Draw()
        {
            _spriteBatch.Begin();

            foreach (Entity entity in _entityManager.Entities.Values)
            {
                if (!_positionMapper.Has(entity.Id))
                    continue;

                if (!_textureMapper.Has(entity.Id))
                    continue;

                Position pos = _positionMapper.Get(entity.Id);
                Components.Texture texture = _textureMapper.Get(entity.Id);

                _spriteBatch.Draw(
                    texture.Texture2,
                    pos.Vector,
                    null,
                    Color.White,
                    0f,
                    new Vector2(texture.Texture2.Width / 2, texture.Texture2.Height / 2),
                    Vector2.One,
                    SpriteEffects.None,
                    0f
                );
            }

            _spriteBatch.End();
        }

        public void Initialize(EntityManager entityManager, IComponentMapperService componentMapperService)
        {
            _entityManager = entityManager;
            _positionMapper = componentMapperService.GetMapper<Position>();
            _textureMapper = componentMapperService.GetMapper<Components.Texture>();
        }
    }
}
