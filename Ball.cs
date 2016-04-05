using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace TP_Pong
{
    class Ball : Sprite
    {
        private int m_screenW;
        private int m_screenH;
        private SoundEffect BallBWall;
        private SoundEffect BallBPong;

        public Ball(int screenW, int screenH)
        {
            m_screenH = screenH;
            m_screenW = screenW;
        }
        public override void initliaze()
        {
            speed = 0.2f;
            dir = new Vector2(1, 1);
        }
        public override void loadContent(ContentManager content, string assetName)
        {
            base.loadContent(content, assetName);
            BallBPong = content.Load<SoundEffect>("ballPong");
            BallBWall = content.Load<SoundEffect>("BallWall");
        }
        public void update(GameTime gameTime, Rectangle r1, Rectangle r2)
        {
           
            if (((pos.Y <= 0 || pos.Y >= m_screenH) && dir.Y < 0 ) 
                || ((pos.Y <= 0 || pos.Y >= m_screenH - texture.Height) && dir.Y > 0))
            {
                dir.Y = -dir.Y;
                BallBWall.Play();
            }
            if((dir.X < 0 && r1.Intersects(this.Rec)) || (dir.X > 0 && r2.Intersects(this.Rec)))
            {
                dir.X = -dir.X;
                BallBPong.Play();
            }
            base.update(gameTime);
        }
    }
}
