using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace FlatWhite.Objects
{
    internal interface IInputComponent
    {
        public void Update(GameObject gameObject, GameTime gameTime);
    }
}
