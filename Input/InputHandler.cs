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

            // TODO: Allow registering of Keys and Controller Buttons to Inputs
            // do we need a separate? Maybe use chain of command or observer pattern to handle both and combine commands bitwise?


            var kstate = Keyboard.GetState();

            if (kstate.GetPressedKeyCount() == 0)
                return commands;

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
