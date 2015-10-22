using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace InsertNameHere
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Dictionary<string, Texture2D> textureCache = new Dictionary<string, Texture2D>();
        TileMatrix mat;
        Tile Cursor;
        int ButtonCooldown = 0;
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
            Cursor = new Tile(Content.Load<Texture2D>("RedBorder.png"));
            mat = new TileMatrix(100, 100, Content.Load<Texture2D>("gras.png"));
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (ButtonCooldown <= 0)
            {
                if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
                {
                    Cursor.SetPosition(Cursor.xPosition - 100, Cursor.yPosition);
                    ButtonCooldown = 10;
                }
                if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
                {
                    Cursor.SetPosition(Cursor.xPosition + 100, Cursor.yPosition);
                    ButtonCooldown = 10;
                }
                if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
                {
                    Cursor.SetPosition(Cursor.xPosition, Cursor.yPosition - 100);
                    ButtonCooldown = 10;
                }
                if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
                {
                    Cursor.SetPosition(Cursor.xPosition, Cursor.yPosition + 100);
                    ButtonCooldown = 10;
                }
            }
            // TODO: Add your update logic here
            if (ButtonCooldown > 0)
            {
                ButtonCooldown--;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            // TODO: Add your drawing code here
            mat.Draw(spriteBatch);

            Cursor.Draw(spriteBatch);
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
