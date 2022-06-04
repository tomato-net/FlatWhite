using FlatWhite.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatWhite.Core
{
    internal class Camera
    {
        public Matrix Transform { get; private set; }
        private GraphicsDevice _graphicsDevice;

        public Camera(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public void MoveTo(Vector2 target)
        {
            Transform = Matrix.CreateTranslation(-target.X, -target.Y, 0) * Matrix.CreateScale(1.5f, 1.5f, 1) * Matrix.CreateTranslation(_graphicsDevice.Viewport.Width / 2, _graphicsDevice.Viewport.Height / 2, 0);
        }
    }
}
