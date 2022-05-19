using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatWhite.Entities.Systems
{
    internal class SystemManager
    {
        private readonly List<IUpdateSystem> _updateSystems = new List<IUpdateSystem>();
        private readonly List<IDrawSystem> _drawSystems = new List<IDrawSystem>();
        private readonly EntityManager _entityManager;
        private readonly ComponentManager _componentManager;

        public SystemManager(EntityManager entityManager, ComponentManager componentManager)
        {
            _entityManager = entityManager;
            _componentManager = componentManager;
        }

        public void AddSystem(ISystem system)
        {
            if (system is IDrawSystem drawSystem)
                _drawSystems.Add(drawSystem);

            if (system is IUpdateSystem updateSystem)
                _updateSystems.Add(updateSystem);

            system.Initialize(_entityManager, _componentManager);
        }

        public void Update(GameTime gameTime)
        {
            foreach (IUpdateSystem updateSystem in _updateSystems)
                updateSystem.Update(gameTime);
        }

        public void Draw()
        {
            foreach (IDrawSystem drawSystem in _drawSystems)
                drawSystem.Draw();
        }
    }
}
