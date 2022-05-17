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
            var kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Up))
                gameObject.position.Y -= gameObject.velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Down))
                gameObject.position.Y += gameObject.velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Left))
                gameObject.position.X -= gameObject.velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Right))
                gameObject.position.X += gameObject.velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
