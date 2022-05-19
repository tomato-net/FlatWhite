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

        public void Follow(GameObject gameObject)
        {
            Transform = Matrix.CreateTranslation(-gameObject.Position.X, -gameObject.Position.Y, 0) * Matrix.CreateScale(2, 2, 1) * Matrix.CreateTranslation(2560 / 2, 1440/2, 0);
        }
    }
}
