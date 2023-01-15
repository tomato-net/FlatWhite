using FlatWhite.Objects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatWhite.Commands
{
    internal class MoveCommand: ICommand
    {
        private GameObject _gameObject;
        private Vector2 _velocity;

        MoveCommand(GameObject gameObject, Vector2 velocity)
        {
            _gameObject = gameObject;
            _velocity = velocity;
        }

        public void Execute()
        {
            Vector2 position = _gameObject.Position + _velocity;
            _gameObject.Position = position;
        }
    }
}
