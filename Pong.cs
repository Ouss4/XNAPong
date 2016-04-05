using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TP_Pong
{
    class Pong : Sprite
    {
        private int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        private Vector2 strPos;
        public Vector2 StrPos
        {
            set { strPos = value; }
        }
        private bool onTop;
        public bool OnTop
        {
            get { return onTop; }
            set { onTop = value; }
        }
        private bool onBottom;
        public bool OnBottom
        {
            get { return onBottom; }
            set { onBottom = value; }
        }
        public override void initliaze()
        {
            score = 0;
            strPos = Vector2.Zero;
            speed = 0.2f;
            onTop = false;
            onBottom = false;
            base.initliaze();
        }
        public void drawStr(SpriteBatch spriteBatch,SpriteFont font, GameTime gameTime)
        {
            spriteBatch.DrawString(font,  score.ToString(), strPos, Color.White);
        }
    }
}
