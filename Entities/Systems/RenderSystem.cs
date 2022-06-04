using FlatWhite.Core;
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
    internal class RenderSystem : EntitySystem, IDrawSystem, IUpdateSystem
    {
        private readonly GraphicsDevice _graphicsDevice;
        private readonly SpriteBatch _spriteBatch;
        private ComponentMapper<Transform2> _positionMapper;
        private ComponentMapper<Components.Texture2> _textureMapper;
        private Camera _camera;

        public RenderSystem(GraphicsDevice graphicsDevice, Camera camera): base(Aspect.All(typeof(Transform2), typeof(Texture2)))
        {
            _graphicsDevice = graphicsDevice;
            _spriteBatch = new SpriteBatch(graphicsDevice);
            _camera = camera;
        }

        public void Update(GameTime gameTime)
        {
            foreach (var entityId in ActiveEntities)
            {
                Transform2 pos = _positionMapper.Get(entityId);
                _camera.MoveTo(pos.Vector);
                break;
            }
        }

        public void Draw()
        {
            _spriteBatch.Begin(transformMatrix: _camera.Transform);

            foreach (var entityId in ActiveEntities)
            {
                Transform2 pos = _positionMapper.Get(entityId);
                Components.Texture2 texture = _textureMapper.Get(entityId);

                _spriteBatch.Draw(
                    texture.Texture,
                    pos.Vector,
                    null,
                    Color.White,
                    0f,
                    new Vector2(texture.Texture.Width / 2, texture.Texture.Height / 2),
                    Vector2.One,
                    SpriteEffects.None,
                    0f
                );
            }

            _spriteBatch.End();
        }

        public override void Initialize(IComponentMapperService componentMapperService)
        {
            _positionMapper = componentMapperService.GetMapper<Transform2>();
            _textureMapper = componentMapperService.GetMapper<Components.Texture2>();
        }
    }
}
