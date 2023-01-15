using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatWhite.Entities.Systems
{
    internal interface IUpdateSystem: ISystem
    {
        public void Update(GameTime gameTime);
    }
}
