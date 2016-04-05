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
    class Sprite
    {
        #region attributes
        protected Rectangle rec;
        public Rectangle Rec
        {
            get 
            {
                return new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height); 
            }
        }
        protected Texture2D texture;
        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }
        protected Vector2 pos;
        public Vector2 Pos
        {
            get { return pos; }
            set { pos = value; }
        }
        protected Vector2 dir;
        public Vector2 Dir
        {
            get { return dir; }
            set { dir = value; }
        }
        protected float speed;
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        #endregion
        public virtual void initliaze()
        {
            pos = Vector2.Zero;
            dir = Vector2.Zero;
            rec = Rectangle.Empty;
        }
        public virtual void initliaze(int x, int y)
        {
            pos = new Vector2(x, y);
        }
        public virtual void loadContent(ContentManager content, string assetName)
        {
            texture = content.Load<Texture2D>(assetName);
        }
        public virtual void update(GameTime gameTime)
        {
            rec = new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height);
            pos += dir * speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
       }
        public virtual void handelInPut(KeyboardState keystate, MouseState mouseState)
        {
        }
        public virtual void draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture, pos, Color.White);
        }
    }
}

