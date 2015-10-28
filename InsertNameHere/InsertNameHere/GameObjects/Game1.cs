using InsertNameHere.Controller;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Concurrent;
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
        ConcurrentDictionary<string, Texture2D> textureCache = new ConcurrentDictionary<string, Texture2D>();
        Level l1;

        Camera2D camera;
        private bool userRequestedFullScreen = false;
        private int userRequestedHeight = 600;
        private int userRequestedWidth = 800;
        SpriteFont std_font;

        int _total_frames = 0;
        float _elapsed_time = 0.0f;
        int _fps = 0;

        bool firstrun = true;
        public Game1()
        {
            AppDomain.CurrentDomain.UnhandledException += LogUnhandled;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        private void LogUnhandled(object sender, UnhandledExceptionEventArgs e)
        {
            Logger.Shoot((e.ExceptionObject as Exception).Message + "\n" + (e.ExceptionObject as Exception).StackTrace);
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

            Logger.Shoot("Begin Loading Textures");
            DateTime dt = DateTime.Now;
            // TODO: use this.Content to load your game content here
            textureCache.TryAdd("BaseTexture", Content.Load<Texture2D>("gras.png"));
            textureCache.TryAdd("BuildCursor", Content.Load<Texture2D>("RedBorder.png"));
            textureCache.TryAdd("Stone", Content.Load<Texture2D>("stein.png"));
            textureCache.TryAdd("WoodWall", Content.Load<Texture2D>("holzwand.png"));
            textureCache.TryAdd("WoodWallCorner", Content.Load<Texture2D>("holzwandecke.png"));
            textureCache.TryAdd("MenuBar", Content.Load<Texture2D>("Menüleiste.png"));
            textureCache.TryAdd("MenuBarEnding", Content.Load<Texture2D>("Menüleistenendung.png"));
            long ms = (DateTime.Now.Ticks - dt.Ticks) / 1000;
            Logger.Shoot("Finished Loading Textures (" + ms + ")");
            //std_font = Content.Load<SpriteFont>("stdfont");
            Logger.Shoot("Start Generating Level");
            dt = DateTime.Now;
            l1.SetGraphicDevice(GraphicsDevice);
            l1.Load();
            ms = (DateTime.Now.Ticks - dt.Ticks) / 1000;
            Logger.Shoot("Finished Generating Level (" + ms + ")");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content 
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Update
            _elapsed_time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
           
            // 1 Second has passed
            if (_elapsed_time >= 1000.0f)
            {
                _fps = _total_frames;
                _total_frames = 0;
                _elapsed_time = 0;
                Logger.Shoot("FPS = " + _fps.ToString());
            }

            if (firstrun)
            {
                Logger.Shoot("Applying Usersettings");
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
            _total_frames++;
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
