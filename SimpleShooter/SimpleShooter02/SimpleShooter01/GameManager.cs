//2020 Levi D. Smith - levidsmith.com
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SimpleShooter {
    public class GameManager : Game {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        KeyboardState previousState;

        Ship ship;
        Dictionary<string, Texture2D> sprites;
        public const int SCREEN_WIDTH = 1280;
        public const int SCREEN_HEIGHT = 720;
        public const int UNIT_SIZE = 64;
        public float deltaTime = 0f;

        public GameManager() {
            graphics = new GraphicsDeviceManager(this);
            

           

            

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here
            this.Window.Title = "Simple Shooter - 2020 Levi D. Smith";
            graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;
//            this.Window.AllowUserResizing = true;
            graphics.ApplyChanges();


            ship = new Ship(this);

            previousState = Keyboard.GetState();

            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            sprites = new Dictionary<string, Texture2D>();
            Texture2D sprite = Content.Load<Texture2D>("ship");
            sprites.Add("ship", sprite);
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            handleKeyboard();

            // TODO: Add your update logic here
            deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;
            ship.Update();

            base.Update(gameTime);
        }

        private void handleKeyboard() {
            KeyboardState state = Keyboard.GetState();
            Keys key;

            key = Keys.A;
            if (state.IsKeyDown(key) && !previousState.IsKeyDown(key)) {
                ship.vel_x = -2f;
            }

            key = Keys.D;
            if (state.IsKeyDown(key) && !previousState.IsKeyDown(key)) {
                ship.vel_x = 2f;
            }

            key = Keys.S;
            if (state.IsKeyDown(key) && !previousState.IsKeyDown(key)) {
                ship.vel_y = 2f;
            }

            key = Keys.W;
            if (state.IsKeyDown(key) && !previousState.IsKeyDown(key)) {
                ship.vel_y = -2f;
            }

            previousState = state;

        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            ship.Draw(spriteBatch, sprites);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
