using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FlatWhite.Objects;
using FlatWhite.Core;
using FlatWhite.Entities;
using FlatWhite.Entities.Systems;

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
            _graphics.PreferredBackBufferWidth = 2560;
            _graphics.PreferredBackBufferHeight = 1440;
            _graphics.ToggleFullScreen();
            _graphics.HardwareModeSwitch = false;
            _graphics.ApplyChanges();

            _camera = new Camera();
            _componentManager = new ComponentManager();
            _entityManager = new EntityManager(_componentManager);
            _systemManager = new SystemManager(_entityManager, _componentManager);
            _systemManager.AddSystem(new MovementSystem());
            _systemManager.AddSystem(new RenderSystem(GraphicsDevice, _camera));

            base.Initialize();
        }

        protected override void LoadContent()
        {

            ballTexture = Content.Load<Texture2D>("ball");

            Entity ball = _entityManager.CreateEntity();
            ball.Attach(new Entities.Components.Position() { Vector = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2)});
            ball.Attach(new Entities.Components.Physics() { Speed = 100f });
            ball.Attach(new Entities.Components.Texture() { Texture2 = ballTexture });

            Entity ball2 = _entityManager.CreateEntity();
            ball2.Attach(new Entities.Components.Position() { Vector = new Vector2(_graphics.PreferredBackBufferWidth / 3, _graphics.PreferredBackBufferHeight / 3)});
            ball2.Attach(new Entities.Components.Physics() { Speed = 90f });
            ball2.Attach(new Entities.Components.Texture() { Texture2 = ballTexture });
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
