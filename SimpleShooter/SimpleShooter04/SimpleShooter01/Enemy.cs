//2020 Levi D. Smith - levidsmith.com
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleShooter {
    class Enemy {
        public float x;
        public float y;
        public int w;
        public int h;
        GameManager gamemanager;

        float fCountdown;
        float fCountdownMax;
        float fSpeed;

        float vel_x;
        float vel_y;

        public Enemy(GameManager in_gamemanager) {

            gamemanager = in_gamemanager;
            w = GameManager.UNIT_SIZE;
            h = GameManager.UNIT_SIZE;

            x = 4f * GameManager.UNIT_SIZE;
            y = 2f * GameManager.UNIT_SIZE;


            fSpeed = 2f;

            vel_x = fSpeed;
            vel_y = 0f;


            fCountdownMax = 2f;
            fCountdown = fCountdownMax;

        }

        public void Update() {
            fCountdown -= gamemanager.deltaTime;
            if (fCountdown <= 0f) {
                vel_x *= -1f;
                fCountdown = fCountdownMax;
            }

            x += vel_x;


        }

        public void Draw(SpriteBatch spritebatch, Dictionary<string, Texture2D> sprites) {
            spritebatch.Draw(sprites["enemy"], new Rectangle((int)x, (int)y, w, h), Color.White);

        }


    }
}
