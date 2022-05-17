using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace FlatWhite.Objects
{
    internal class DemoPlayerInputComponent: IInputComponent
    {
        public void Update(GameObject gameObject, GameTime gameTime)
        {
            gameObject.position.Y += gameObject.velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            gameObject.position.X += gameObject.velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
