using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TP_Pong
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region attributes
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private SpriteFont font;
        private Pong pong;
        private Pong pong2;
        private Ball ball;
        private KeyboardState keystate;

        private bool p1Won;
        private bool p2Won;
        private bool pause;
        #endregion
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;
            Window.Title = "Ping Pong";
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            pong = new Pong();
            pong2 = new Pong();
            ball = new Ball(Window.ClientBounds.Width, Window.ClientBounds.Height);

            pong.initliaze();
            pong2.initliaze();
            ball.initliaze();

            pong.StrPos = new Vector2(160, 40);
            pong2.StrPos = new Vector2(600, 40);

            p1Won = false;
            p2Won = false;
            pause = true;

            base.Initialize();
        }
       private void startingPos()
        {
            pong.initliaze(0, Window.ClientBounds.Height / 2 - pong.Texture.Height / 2);
            pong2.initliaze(Window.ClientBounds.Width - pong2.Texture.Width,
                            Window.ClientBounds.Height / 2 - pong2.Texture.Height / 2);
            ball.initliaze(Window.ClientBounds.Width /2 - ball.Texture.Width / 2,
                            Window.ClientBounds.Height / 2 - ball.Texture.Height / 2);
        }
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("SpriteFont1");

            // TODO: use this.Content to load your game content here
            pong.loadContent(Content, "pong");
            pong2.loadContent(Content, "pong");
            ball.loadContent(Content, "ball");
            startingPos();
        }
        protected override void UnloadContent()
        {
        }
        private void ballGoingOut()
        {
            if ((int)ball.Pos.X <= 0 )
                p2Won = true;
            if ((int)ball.Pos.X >= Window.ClientBounds.Width)
                p1Won = true;
        }
        private void handleInPut()
        {
            if (pong.Pos.Y <= 0)
            {
                pong.Dir = Vector2.Zero;
                pong.OnTop = true;
                pong.Speed = 0.2f;
            }
            if (pong.Pos.Y + pong.Texture.Height >= Window.ClientBounds.Height)
            {
                pong.Dir = Vector2.Zero;
                pong.OnBottom = true;
                pong.Speed = 0.2f;
            }
            if (pong2.Pos.Y <= 0)
            {
                pong2.Dir = Vector2.Zero;
                pong2.OnTop = true;
                pong2.Speed = 0.2f;

            }
            if (pong2.Pos.Y + pong2.Texture.Height >= Window.ClientBounds.Height)
            {
                pong2.Dir = Vector2.Zero;
                pong2.OnBottom = true;
                pong2.Speed = 0.2f;
            }
            if (keystate.IsKeyDown(Keys.Up))
            {
                if (!pong.OnTop)
                {
                    pong.Dir = new Vector2(0, -1);
                    pong.Speed += 0.01f;
                    pong.OnBottom = false;
                }
            }
            else if (keystate.IsKeyDown(Keys.Down))
            {
                if (!pong.OnBottom)
                {
                    pong.Dir = new Vector2(0, 1);
                    pong.Speed += 0.01f;
                    pong.OnTop = false;
                }
            }
            else if (keystate.IsKeyDown(Keys.D))
            {
                if (!pong2.OnBottom)
                {
                    pong2.Dir = new Vector2(0, 1);
                    pong2.Speed += 0.01f;
                    pong2.OnTop = false;
                }
            }
            else if (keystate.IsKeyDown(Keys.A))
            {
                if (!pong2.OnTop)
                {
                    pong2.Dir = new Vector2(0, -1);
                    pong2.Speed += 0.002f;
                    pong2.OnBottom = false;
                }
            }
            if (keystate.IsKeyUp(Keys.Up) && keystate.IsKeyUp(Keys.Down))
            {
                pong.Dir = Vector2.Zero;
                pong.Speed = 0.2f;
            }
            if (keystate.IsKeyUp(Keys.A) && keystate.IsKeyUp(Keys.D))
            {
                pong2.Dir = Vector2.Zero;
                pong2.Speed = 0.2f;
            }
        }
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            keystate = Keyboard.GetState();
            #region updates
            if (!pause)
            {
                pong.update(gameTime);
                pong2.update(gameTime);
                ball.update(gameTime, pong.Rec, pong2.Rec);
            }
            else if (keystate.IsKeyDown(Keys.Space))
                pause = false;
            #endregion
            #region test If The Ball Crossed The Boards
            ballGoingOut();
            if (p1Won)
            {
                pong.Score += 10;
                startingPos();
                p1Won = false;
                pause = true;
            }
            if (p2Won)
            {
                pong2.Score += 10;
                startingPos();
                p2Won = false;
                pause = true;
            }
            #endregion
            
            handleInPut();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            pong.draw(spriteBatch, gameTime);
            pong2.draw(spriteBatch, gameTime);
            ball.draw(spriteBatch, gameTime);
            pong.drawStr(spriteBatch, font, gameTime);
            pong2.drawStr(spriteBatch, font, gameTime);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
