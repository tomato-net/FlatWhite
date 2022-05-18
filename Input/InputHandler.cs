using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatWhite.Input
{
    public enum Inputs
    {
        MoveRight,
        MoveLeft,
        MoveUp,
        MoveDown,
    }

    internal class InputHandler
    {

        public static List<Inputs> GetInputs()
        {   
            List<Inputs> commands = new List<Inputs>();

            var kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Up))
                commands.Add(Inputs.MoveUp);

            if (kstate.IsKeyDown(Keys.Down))
                commands.Add(Inputs.MoveDown);

            if (kstate.IsKeyDown(Keys.Left))
                commands.Add(Inputs.MoveLeft);

            if (kstate.IsKeyDown(Keys.Right))
                commands.Add(Inputs.MoveRight);

            return commands;
        }
    }
}
