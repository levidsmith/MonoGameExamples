using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleShooter {
    class Bullet {
        public float x;
        public float y;
        public int w;
        public int h;
        GameManager gamemanager;

        public float vel_x;
        public float vel_y;

        public float fSpeed;
        public float fLifeTime;
        public bool isAlive;

        public Bullet(GameManager init_gamemanager, int init_x, int init_y) {
            gamemanager = init_gamemanager;
            w = GameManager.UNIT_SIZE / 4;
            h = GameManager.UNIT_SIZE / 4;

            x = init_x;
            y = init_y;


            fSpeed = 8f;

            vel_x = 0f;
            vel_y = -fSpeed;

            fLifeTime = 0f;
            isAlive = true;


        }

        public void Draw(SpriteBatch spritebatch, Dictionary<string, Texture2D> sprites) {
            spritebatch.Draw(sprites["bullet"], new Rectangle((int)x, (int)y, w, h), Color.White);

        }

        public void Update() {
            x += vel_x * GameManager.UNIT_SIZE * gamemanager.deltaTime;
            y += vel_y * GameManager.UNIT_SIZE * gamemanager.deltaTime;

            fLifeTime += gamemanager.deltaTime;
            if (fLifeTime > 5f) {
                isAlive = false;
                //destroy bullet
            }

        }



    }
}
