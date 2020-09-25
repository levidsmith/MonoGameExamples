using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleShooter {
    class Ship {
        public float x;
        public float y;
        public int w;
        public int h;
        GameManager gamemanager;

        public float vel_x;
        public float vel_y;

        public Ship(GameManager in_gamemanager) {
            gamemanager = in_gamemanager;
            w = GameManager.UNIT_SIZE;
            h = GameManager.UNIT_SIZE;

            x = (GameManager.SCREEN_WIDTH - w) / 2f;
            y = (GameManager.SCREEN_HEIGHT - h) / 2f;

            vel_x = 0f;
            vel_y = 0f;

        }

        public void Draw(SpriteBatch spritebatch, Dictionary<string, Texture2D> sprites) {
            spritebatch.Draw(sprites["ship"], new Rectangle((int) x, (int) y, w, h), Color.White);

        }

        public void Update() {
            x += vel_x * GameManager.UNIT_SIZE * gamemanager.deltaTime;
            y += vel_y * GameManager.UNIT_SIZE * gamemanager.deltaTime;

        }
        
    }
}
