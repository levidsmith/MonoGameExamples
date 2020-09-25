using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleShooter {
    public class Enemy {
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

        public bool isAlive;

        public Enemy(GameManager in_gamemanager, int init_x, int init_y) {

            gamemanager = in_gamemanager;
            w = GameManager.UNIT_SIZE;
            h = GameManager.UNIT_SIZE;

            x = (4 + init_x) * GameManager.UNIT_SIZE;
            y = (2f + init_y) * GameManager.UNIT_SIZE;


            fSpeed = 2f;

            vel_x = fSpeed;
            vel_y = 0f;


            fCountdownMax = 2f;
            fCountdown = fCountdownMax;
            isAlive = true;

        }

        public void Update() {
            if (isAlive) {
                fCountdown -= gamemanager.deltaTime;
                if (fCountdown <= 0f) {
                    vel_x *= -1f;
                    fCountdown = fCountdownMax;
                }

                x += vel_x;
            }

            Ship ship = gamemanager.ship;
            if (getRectangle().Intersects(ship.getRectangle())) {
                ship.isAlive = false;

            }



        }

        public void Draw(SpriteBatch spritebatch, Dictionary<string, Texture2D> sprites) {
            if (isAlive) {
                spritebatch.Draw(sprites["enemy"], new Rectangle((int)x, (int)y, w, h), Color.White);
            }

        }

        public Rectangle getRectangle() {
            return new Rectangle((int)x, (int)y, w, h);
        }



    }
}
