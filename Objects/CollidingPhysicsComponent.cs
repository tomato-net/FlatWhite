using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatWhite.Objects
{
    internal class CollidingPhysicsComponent: IPhysicsComponent
    {
        public void Update(GameObject gameObject, GameTime gameTime)
        {
            Vector2 position = gameObject.Position;
            position += gameObject.Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            gameObject.Position = position;
        }
    }
}
