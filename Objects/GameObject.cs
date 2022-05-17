using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlatWhite.Objects
{
    internal class GameObject
    {
        public Vector2 position;
        public float velocity;
        IInputComponent _input;
        IGraphicsComponent _graphics;

        public GameObject(IInputComponent input, IGraphicsComponent graphics)
        {
            _input = input;
            _graphics = graphics;
            position = new Vector2(100f, 100f);
            velocity = 200f;
        }

        public void Update(GameTime gameTime)
        {
            _input.Update(this, gameTime);
            _graphics.Update(this, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _graphics.Draw(spriteBatch, this);
        }
    }
}
