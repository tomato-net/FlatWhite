using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatWhite.Entities
{
    internal class AspectBuilder
    {
        List<Type> AllTypes = new List<Type>();

        public AspectBuilder All(params Type[] types)
        {
            AllTypes.AddRange(types);

            return this;
        }

        public Aspect Build(ComponentManager componentManager)
        {
            return new Aspect() { AllSet = TypeBits(componentManager, AllTypes)};
        }

        public BitVector32 TypeBits(ComponentManager componentManager, List<Type> types)
        {
            BitVector32 b = new BitVector32();
            foreach (var type in types)
            {
                int id = componentManager.GetComponentTypeId(type);
                b[1 << id] = true;
            }

            return b;
        }
    }
}
