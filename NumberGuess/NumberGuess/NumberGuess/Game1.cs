//2020 Levi D. Smith - levidsmith.com
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace NumberGuess {
    public class Game1 : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont myFont;
        private string strGuess;
        private string strResult;
        KeyboardState previousState;

        private int iSecretNumber;
        private int iGuessCount;
        private bool isGameOver;

        public Game1() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here

            base.Initialize();

            restart();

            previousState = Keyboard.GetState();
        }

        private void restart() {
            isGameOver = false;
            Random r = new Random();
            iSecretNumber = r.Next(1, 100);

            iGuessCount = 0;

            strGuess = "";
            strResult = "";
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            myFont = Content.Load<SpriteFont>("MyFont");
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState state = Keyboard.GetState();

            Keys key;

            if (!isGameOver) {

                int i;
                for (i = 0; i <= 9; i++) {
                    key = Keys.D0 + i;
                    if (state.IsKeyDown(key) && !previousState.IsKeyDown(key)) {
                        if (strGuess.Length < 2) {
                            strGuess += i.ToString();
                        }
                    }
                }

                key = Keys.Back;
                if (state.IsKeyDown(key) && !previousState.IsKeyDown(key)) {
                    if (strGuess.Length > 0) {
                        strGuess = strGuess.Substring(0, strGuess.Length - 1);
                    }
                }

                key = Keys.Enter;
                if (state.IsKeyDown(key) && !previousState.IsKeyDown(key)) {
                    if (strGuess.Length > 0) {
                        checkGuess(int.Parse(strGuess));
                    }
                }
            } else {

                key = Keys.Enter;
                if (state.IsKeyDown(key) && !previousState.IsKeyDown(key)) {
                        restart();
                }


            }
            base.Update(gameTime);
            previousState = state;
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.DrawString(myFont, "Guess the number\nbetween 1 and 100", new Vector2(100, 100), Color.White);
            _spriteBatch.DrawString(myFont, strGuess, new Vector2(100, 200), Color.Yellow);
            _spriteBatch.DrawString(myFont, strResult, new Vector2(100, 300), Color.Red);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void checkGuess(int iGuess) {
            iGuessCount++;
            strGuess = "";

            if (iGuess < iSecretNumber) {
                strResult = iGuess + ": Higher";
            } else if (iGuess > iSecretNumber) {
                strResult = iGuess + ": Lower";
            } else if (iGuess == iSecretNumber) {
                strResult = iGuess + ": Correct!\n" + iGuessCount + " total guesses";
                isGameOver = true;
            }
        }
    }
}
