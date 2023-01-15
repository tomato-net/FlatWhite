using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FlatWhite.Objects;
using FlatWhite.Core;
using FlatWhite.Entities;
using FlatWhite.Entities.Systems;
using FlatWhite.Entities.Components;

namespace FlatWhite
{
    public class FlatWhite : Game
    {
        public static readonly string version = "0.0.1";

        private GraphicsDeviceManager _graphics;
        private Camera _camera;

        private ComponentManager _componentManager;
        private EntityManager _entityManager;
        private SystemManager _systemManager;

        private Texture2D ballTexture;

        public FlatWhite()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // _graphics.PreferredBackBufferWidth = 2560;
            // _graphics.PreferredBackBufferHeight = 1440;
            // _graphics.ToggleFullScreen();
            // _graphics.HardwareModeSwitch = false;
            // _graphics.ApplyChanges();

            _camera = new Camera(_graphics.GraphicsDevice);
            _componentManager = new ComponentManager();
            _entityManager = new EntityManager(_componentManager);
            _systemManager = new SystemManager(_entityManager, _componentManager);
            _systemManager.AddSystem(_entityManager);
            _systemManager.AddSystem(new MovementSystem());
            _systemManager.AddSystem(new RenderSystem(GraphicsDevice, _camera));

            base.Initialize();
        }

        protected override void LoadContent()
        {

            ballTexture = Content.Load<Texture2D>("ball");

            Entity ball = _entityManager.CreateEntity()
                .Attach(new Transform2() { Vector = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2)})
                .Attach(new Physics() { Speed = 100f })
                .Attach(new Texture2() { Texture = ballTexture });

            Entity ball2 = _entityManager.CreateEntity()
                .Attach(new Transform2() { Vector = new Vector2(_graphics.PreferredBackBufferWidth / 3, _graphics.PreferredBackBufferHeight / 3)})
                .Attach(new Physics() { Speed = 90f })
                .Attach(new Texture2() { Texture = ballTexture });
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _systemManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _systemManager.Draw();

            base.Draw(gameTime);
        }
    }
}
