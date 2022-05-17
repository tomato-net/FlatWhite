using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlatWhite.Objects
{
    internal interface IGraphicsComponent
    {
        public void Update(GameObject gameObject, GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch, GameObject gameObject);
    }
}
