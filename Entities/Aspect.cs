using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatWhite.Entities
{
    internal class Aspect
    {
        public BitVector32 AllSet { get; set; } = new BitVector32();

        public static AspectBuilder All(params Type[] types)
        {
            return new AspectBuilder().All(types);
        }

        public bool IsInterested(BitVector32 componentBits)
        {
            if (AllSet.Data != 0 && (AllSet.Data & componentBits.Data) != AllSet.Data)
                return false;

            return true;
        }
    }
}
