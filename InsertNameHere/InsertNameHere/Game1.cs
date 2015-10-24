using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
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
        Level l1;

        Camera2D camera;
        private bool userRequestedFullScreen = false;
        private int userRequestedHeight = 600;
        private int userRequestedWidth = 800;
        bool firstrun = true;
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
            l1 = new Level(textureCache);
            camera = new Camera2D(this, l1.Cursor);
            Components.Add(camera);
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
            textureCache.Add("BaseTexture", Content.Load<Texture2D>("gras.png"));
            textureCache.Add("BuildCursor", Content.Load<Texture2D>("RedBorder.png"));
            textureCache.Add("Stone", Content.Load<Texture2D>("stein.png"));
            textureCache.Add("WoodWall", Content.Load<Texture2D>("holzwand.png"));
            textureCache.Add("WoodWallCorner", Content.Load<Texture2D>("holzwandecke.png"));
            textureCache.Add("MenuBar", Content.Load<Texture2D>("Menüleiste.png"));
            textureCache.Add("MenuBarEnding", Content.Load<Texture2D>("Menüleistenendung.png"));
            l1.SetGraphicDevice(GraphicsDevice);
            l1.Load();
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
            if (firstrun)
            {
                string fs, rh, rw;
                LaunchParameters.TryGetValue("Fullscreen", out fs);
                LaunchParameters.TryGetValue("Height", out rh);
                LaunchParameters.TryGetValue("Width", out rw);
                try
                {
                    int.TryParse(rh, out userRequestedHeight);
                    int.TryParse(rw, out userRequestedWidth);
                    userRequestedFullScreen = fs == "yes";
                }
                catch (System.Exception)
                {
                    throw;
                }

                graphics.IsFullScreen = userRequestedFullScreen;
                graphics.PreferredBackBufferHeight = userRequestedHeight;
                graphics.PreferredBackBufferWidth = userRequestedWidth;
                graphics.ApplyChanges();
                camera.ScreenCenter = new Vector2(userRequestedWidth / 2, userRequestedHeight / 2);
                firstrun = false;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
           
            l1.UpdateButtons(gameTime);
            
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.Transform);
            // TODO: Add your drawing code here
            l1.Draw(spriteBatch, camera);
            base.Draw(gameTime);
            spriteBatch.End();

            spriteBatch.Begin();
            l1.DrawOnScreen(spriteBatch, null);
            spriteBatch.End();
        }
    }
}
