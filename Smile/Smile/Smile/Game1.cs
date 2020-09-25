//2020 Levi D. Smith - levidsmith.com
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Smile {
    public class Game1 : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D sprSmile;

        public Game1() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            sprSmile = Content.Load<Texture2D>("smile");
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            int w = sprSmile.Width;
            int h = sprSmile.Height;
            int x = (GraphicsDevice.Viewport.Width - w) / 2;
            int y = (GraphicsDevice.Viewport.Height - h) / 2;

            _spriteBatch.Begin();
            _spriteBatch.Draw(sprSmile, new Rectangle(x, y, w * 2, h), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
