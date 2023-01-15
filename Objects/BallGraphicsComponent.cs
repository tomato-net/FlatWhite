using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FlatWhite.Objects
{
    internal class BallGraphicsComponent: IGraphicsComponent
    {
        Texture2D _sprite;

        public BallGraphicsComponent(Texture2D sprite)
        {
            _sprite = sprite;
        }

        public void Update(GameObject gameObject, GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, GameObject gameObject)
        {
            spriteBatch.Draw(
                _sprite,
                gameObject.Position,
                null,
                Color.White,
                0f,
                new Vector2(_sprite.Width / 2, _sprite.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
             );
        }
    }
}
