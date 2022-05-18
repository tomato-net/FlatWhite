using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using FlatWhite.Input;

namespace FlatWhite.Objects
{
    internal class PlayerInputComponent : IInputComponent
    {
        public void Update(GameObject gameObject, GameTime gameTime)
        {
            Vector2 velocity = new Vector2();

            List<Inputs> inputs = InputHandler.GetInputs();

            if (inputs.Contains(Inputs.MoveUp))
                velocity.Y -= gameObject.Speed;

            if (inputs.Contains(Inputs.MoveDown))
                velocity.Y += gameObject.Speed;

            if (inputs.Contains(Inputs.MoveLeft))
                velocity.X -= gameObject.Speed;

            if (inputs.Contains(Inputs.MoveRight))
                velocity.X += gameObject.Speed;

            gameObject.Velocity = velocity;
        }
    }
}
