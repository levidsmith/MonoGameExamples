//2020 Levi D. Smith - levidsmith.com
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SoundTest {
    public class Game1 : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        SpriteFont myfont;
        KeyboardState previousState = Keyboard.GetState();
        
        List<SoundEffect> sounds;

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

            myfont = Content.Load<SpriteFont>("MyFont");

            sounds = new List<SoundEffect>();

            SoundEffect sound;

            sound = Content.Load<SoundEffect>("Blip_Select85");
            sounds.Add(sound);
            sound = Content.Load<SoundEffect>("Explosion39");
            sounds.Add(sound);
            sound = Content.Load<SoundEffect>("Hit_Hurt41");
            sounds.Add(sound);
            sound = Content.Load<SoundEffect>("Jump18");
            sounds.Add(sound);
            sound = Content.Load<SoundEffect>("Laser_Shoot26");
            sounds.Add(sound);
            sound = Content.Load<SoundEffect>("Pickup_Coin102");
            sounds.Add(sound);
            sound = Content.Load<SoundEffect>("Powerup24");
            sounds.Add(sound);
            sound = Content.Load<SoundEffect>("Randomize11");
            sounds.Add(sound);
            sound = Content.Load<SoundEffect>("Randomize21");
            sounds.Add(sound);
            sound = Content.Load<SoundEffect>("Randomize9");
            sounds.Add(sound);

        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            KeyboardState state = Keyboard.GetState();
            Keys key;
            int i;
            for (i = 0; i <= 9; i++) {
                key = Keys.D0 + i;
                if (state.IsKeyDown(key) && !previousState.IsKeyDown(key)) {
                    sounds[i].Play();
                }
            }


            base.Update(gameTime);
            previousState = state;
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.DrawString(myfont, "Press a number\nto play a sound", new Vector2(100, 100), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
