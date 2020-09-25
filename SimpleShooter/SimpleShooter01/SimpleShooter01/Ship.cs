using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleShooter01 {
    class Ship {
        public float x;
        public float y;
        public int w;
        public int h;
        GameManager gamemanager;

        public Ship(GameManager in_gamemanager) {
            gamemanager = in_gamemanager;
            w = 64;
            h = 64;

            x = (GameManager.SCREEN_WIDTH - w) / 2f;
            
            y = (GameManager.SCREEN_HEIGHT - h) / 2f;

        }

        public void Draw(GameTime gameTime, SpriteBatch spritebatch, Dictionary<string, Texture2D> sprites) {
            spritebatch.Draw(sprites["ship"], new Rectangle((int) x, (int) y, w, h), Color.White);

        }
        
    }
}
