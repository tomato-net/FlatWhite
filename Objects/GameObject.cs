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
        IInputComponent _input;
        IPhysicsComponent _physics;
        IGraphicsComponent _graphics;

        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public float Speed { get; private set; }

        public GameObject(IInputComponent input, IPhysicsComponent physics, IGraphicsComponent graphics)
        {
            _input = input;
            _physics = physics;
            _graphics = graphics;
            Position = new Vector2(100f, 100f);
            Velocity = new Vector2();
            Speed = 200f;
        }

        public void Update(GameTime gameTime)
        {
            _input.Update(this, gameTime);
            _physics.Update(this, gameTime);
            _graphics.Update(this, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _graphics.Draw(spriteBatch, this);
        }
    }
}
