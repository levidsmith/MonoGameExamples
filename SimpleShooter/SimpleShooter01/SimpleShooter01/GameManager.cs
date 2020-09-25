//2020 Levi D. Smith - levidsmith.com
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SimpleShooter01 {
    public class GameManager : Game {
        private GraphicsDeviceManager graphics;
        private SpriteBatch _spriteBatch;

        Ship ship;
        Dictionary<string, Texture2D> sprites;
        public const int SCREEN_WIDTH = 1280;
        public const int SCREEN_HEIGHT = 720;

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

            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            sprites = new Dictionary<string, Texture2D>();
            Texture2D sprite = Content.Load<Texture2D>("ship");
            sprites.Add("ship", sprite);
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            ship.Draw(gameTime, _spriteBatch, sprites);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
