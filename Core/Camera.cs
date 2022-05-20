using FlatWhite.Objects;
using Microsoft.Xna.Framework;
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

        public void MoveTo(Vector2 target)
        {
            Transform = Matrix.CreateTranslation(-target.X, -target.Y, 0) * Matrix.CreateScale(2, 2, 1) * Matrix.CreateTranslation(2560 / 2, 1440/2, 0);
        }
    }
}
