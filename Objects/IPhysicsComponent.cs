using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatWhite.Objects
{
    internal interface IPhysicsComponent
    {
        public void Update(GameObject gameObject, GameTime gameTime);
    }
}
