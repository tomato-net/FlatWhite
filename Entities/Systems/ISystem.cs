using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatWhite.Entities.Systems
{
    internal interface ISystem
    {
        public void Initialize(EntityManager entityManager, IComponentMapperService componentManager);
    }
}
