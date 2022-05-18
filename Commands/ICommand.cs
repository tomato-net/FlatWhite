using FlatWhite.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatWhite.Commands
{
    internal interface ICommand
    {
        public void Execute();
    }
}
