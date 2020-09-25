using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GamepadTest {
    public class Game1 : Game {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        SpriteFont myFont;
        string strPressed;
        string strReleased;
        string strTriggers;
        string strStick;
        string strDPad;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            myFont = Content.Load<SpriteFont>("Arial");
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            strPressed = "";
            strReleased = "";
            if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed) {
                strPressed += "A";
                strReleased += " ";
            } else {
                strPressed += " ";
                strReleased += "A";
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed) {
                strPressed += "B";
                strReleased += " ";
            } else {
                strPressed += " ";
                strReleased += "B";
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed) {
                strPressed += "X";
                strReleased += " ";
            } else {
                strPressed += " ";
                strReleased += "X";
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed) {
                strPressed += "Y";
                strReleased += " ";
            } else {
                strPressed += " ";
                strReleased += "Y";
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.LeftShoulder == ButtonState.Pressed) {
                strPressed += "L1";
                strReleased += "  ";
            } else {
                strPressed += "  ";
                strReleased += "L1";
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.RightShoulder == ButtonState.Pressed) {
                strPressed += "R1";
                strReleased += "  ";
            } else {
                strPressed += "  ";
                strReleased += "R1";
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed) {
                strPressed += "St";
                strReleased += "  ";
            } else {
                strPressed += "  ";
                strReleased += "St";
            }


            if (GamePad.GetState(PlayerIndex.One).Buttons.LeftStick == ButtonState.Pressed) {
                strPressed += "L3";
                strReleased += "  ";
            } else {
                strPressed += "  ";
                strReleased += "L3";
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.RightStick == ButtonState.Pressed) {
                strPressed += "R3";
                strReleased += "  ";
            } else {
                strPressed += "  ";
                strReleased += "R3";
            }


            strTriggers = "";

            strTriggers += "L2: " + string.Format("{0:0.00}", GamePad.GetState(PlayerIndex.One).Triggers.Left);
            strTriggers += " R2: " + string.Format("{0:0.00}", GamePad.GetState(PlayerIndex.One).Triggers.Right);

            strStick = "";
            float x = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X;
            float y = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y;
            float h = (float) Math.Sqrt((double) (Math.Pow(x, 2) + Math.Pow(y, 2)));
            float deg = 0f;
            if (h > 0f) {
                deg = (float)(Math.Asin(y / h));
                deg *= 180f / (float) Math.PI;

                if (x < 0f) {
                    deg = 90 + 90f - deg;
                }

                if (x >= 0f && y < 0f) {
                    deg = 360f + deg;
                }
            }
            strStick += "LS x:" + string.Format("{0:0.00}", x) + " y:" + string.Format("{0:0.00}", y) + 
                " deg:" + string.Format("{0:0.00}", deg);



            x = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X;
            y = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y;
            h = (float)Math.Sqrt((double)(Math.Pow(x, 2) + Math.Pow(y, 2)));
            deg = 0f;
            if (h > 0f) {
                deg = (float)(Math.Asin(y / h));
                deg *= 180f / (float)Math.PI;

                if (x < 0f) {
                    deg = 90 + 90f - deg;
                }

                if (x >= 0f && y < 0f) {
                    deg = 360f + deg;
                }
            }
            strStick += "\nRS x:" + string.Format("{0:0.00}", x) + " y:" + string.Format("{0:0.00}", y) +
                " deg:" + string.Format("{0:0.00}", deg);



            strDPad = "";
            if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed) {
                strDPad += "Up";
            }
            if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed) {
                strDPad += "Down";
            }
            if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed) {
                strDPad += "Left";
            }
            if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed) {
                strDPad += "Right";
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.DrawString(myFont, "Pressed:  " + strPressed, new Vector2(100, 100), Color.White);
            spriteBatch.DrawString(myFont, "Released: " + strReleased, new Vector2(100, 150), Color.Black);
            spriteBatch.DrawString(myFont, strTriggers, new Vector2(100, 200), Color.White);
            spriteBatch.DrawString(myFont, strStick, new Vector2(100, 250), Color.White);
            spriteBatch.DrawString(myFont, "DPad: " + strDPad, new Vector2(100, 350), Color.White);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
