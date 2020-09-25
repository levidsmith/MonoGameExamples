//2020 Levi D. Smith - levidsmith.com
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MouseTest {
    public class Game1 : Game {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        SpriteFont myfont;

        string strMouse;
        Vector2 posMouse;
        bool mouseLeftPressed;
        bool mouseMiddlePressed;
        bool mouseRightPressed;
        int iScrollWheel;


        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here
            strMouse = "";
            posMouse = new Vector2();
            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            myfont = Content.Load<SpriteFont>("MyFont");
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            posMouse = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            mouseLeftPressed = Mouse.GetState().LeftButton == ButtonState.Pressed;
            mouseMiddlePressed = Mouse.GetState().MiddleButton == ButtonState.Pressed;
            mouseRightPressed = Mouse.GetState().RightButton == ButtonState.Pressed;

            strMouse = "Left: ";
            if (mouseLeftPressed) {
                strMouse += "Pressed\n";
            } else {
                strMouse += "Released\n";
            }

            strMouse += "Middle: ";
            if (mouseMiddlePressed) {
                strMouse += "Pressed\n";
            } else {
                strMouse += "Released\n";
            }

            strMouse += "Right: ";
            if (mouseRightPressed) {
                strMouse += "Pressed\n";
            } else {
                strMouse += "Released\n";
            }

            iScrollWheel = Mouse.GetState().ScrollWheelValue;
            strMouse += "Scroll Wheel: " + iScrollWheel;


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.DrawString(myfont, string.Format("Mouse Position: {0:0}, {1:0}", posMouse.X, posMouse.Y), new Vector2(32, 64), Color.White);
            spriteBatch.DrawString(myfont, strMouse, new Vector2(32, 128), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
