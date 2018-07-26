﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Test2DGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Vector2 position;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            position = new Vector2(0, 0);
            texture = new Texture2D(this.GraphicsDevice, 150, 150);
            Color[] ColorData = new Color[150 * 150];
            for (int i = 0; i < 22500; i++)
            {
                ColorData[i] = Color.Green;
                texture.SetData<Color>(ColorData);
            }
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (IsActive)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

                // TODO: Add your update logic here
                //--Controls--\\
                int speed = 2;
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    position.X += speed;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    position.X = position.X - speed;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    position.Y = position.Y - speed;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    position.Y += speed;
                }
                //--WindowColitions--\\
                if (position.X > this.GraphicsDevice.Viewport.Width - 150)
                {
                    position.X = this.GraphicsDevice.Viewport.Width - 150;
                }
                if (position.Y > this.GraphicsDevice.Viewport.Height - 150)
                {
                    position.Y = this.GraphicsDevice.Viewport.Height - 150;
                }
                if (position.X < 0)
                {
                    position.X = 0;
                }
                if (position.Y < 0)
                {
                    position.Y = 0;
                }
                //--Update--\\
                base.Update(gameTime);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
