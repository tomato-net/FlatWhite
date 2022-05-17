using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FlatWhite.Objects
{
    internal class PlayerInputComponent : IInputComponent
    {
        public void Update(GameObject gameObject, GameTime gameTime)
        {
            Vector2 velocity = new Vector2();

            var kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Up))
                velocity.Y -= gameObject.Speed;

            if (kstate.IsKeyDown(Keys.Down))
                velocity.Y += gameObject.Speed;

            if (kstate.IsKeyDown(Keys.Left))
                velocity.X -= gameObject.Speed;

            if (kstate.IsKeyDown(Keys.Right))
                velocity.X += gameObject.Speed;

            gameObject.Velocity = velocity;
        }
    }
}
