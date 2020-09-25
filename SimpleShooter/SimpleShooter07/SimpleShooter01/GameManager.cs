using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SimpleShooter {
    public class GameManager : Game {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        KeyboardState previousState;
        KeyboardState currentState;

        public Ship ship;
        public List<Enemy> enemies;
        public List<Bullet> bullets;

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
            enemies = new List<Enemy>();
            int i;
            for (i = 0; i < 20; i++) {
                Enemy enemy = new Enemy(this, (i % 5) * 2, i / 5);
                enemies.Add(enemy);
            }
            bullets = new List<Bullet>();

            previousState = Keyboard.GetState();

            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            sprites = new Dictionary<string, Texture2D>();
            Texture2D sprite = Content.Load<Texture2D>("ship");
            sprites.Add("ship", sprite);

            sprite = Content.Load<Texture2D>("enemy");
            sprites.Add("enemy", sprite);

            sprite = Content.Load<Texture2D>("bullet");
            sprites.Add("bullet", sprite);


        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            handleKeyboard();

            // TODO: Add your update logic here
            deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;
            ship.Update();
            foreach (Enemy enemy in enemies) {
                enemy.Update();
            }
            foreach (Bullet b in bullets) {
                b.Update();
            }

            base.Update(gameTime);
        }

        private void handleKeyboard() {
            currentState = Keyboard.GetState();
            Keys key;

            if (isKeyPressed(Keys.A)) {
                ship.vel_x = -ship.fSpeed;
            }

            if (isKeyPressed(Keys.S)) {
                ship.vel_y = ship.fSpeed;
            }

            if (isKeyPressed(Keys.D)) {
                ship.vel_x = ship.fSpeed;
            }

            if (isKeyPressed(Keys.W)) {
                ship.vel_y = -ship.fSpeed;
            }


            if (isKeyReleased(Keys.A)) {
                if (ship.vel_x < 0f) {
                    ship.vel_x = 0f;
                }
            }

            if (isKeyReleased(Keys.S)) {
                if (ship.vel_y > 0f) {
                    ship.vel_y = 0f;
                }
            }

            if (isKeyReleased(Keys.D)) {
                if (ship.vel_x > 0f) {
                    ship.vel_x = 0f;
                }
            }

            if (isKeyReleased(Keys.W)) {
                if (ship.vel_y < 0f) {
                    ship.vel_y = 0f;
                }
            }
            
            if (isKeyPressed(Keys.Space)) {
                Bullet bullet = new Bullet(this, (int) ship.x, (int) ship.y);
                bullets.Add(bullet);

            }



            previousState = currentState;

        }

        private bool isKeyPressed(Keys key) {
            bool b;

            if (currentState.IsKeyDown(key) && !previousState.IsKeyDown(key)) {
                b = true;
            } else {
                b = false;
            }
            return b;
        }

        private bool isKeyReleased(Keys key) {
            bool b;

            if (!currentState.IsKeyDown(key) && previousState.IsKeyDown(key)) {
                b = true;
            } else {
                b = false;
            }
            return b;

        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            ship.Draw(spriteBatch, sprites);
            foreach (Enemy enemy in enemies) {
                enemy.Draw(spriteBatch, sprites);
            }
            foreach (Bullet b in bullets) {
                b.Draw(spriteBatch, sprites);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
