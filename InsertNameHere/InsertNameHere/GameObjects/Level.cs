using InsertNameHere.Controller;
using InsertNameHere.Enums;
using InsertNameHere.GameObjects;
using InsertNameHere.GameObjects.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;

namespace InsertNameHere
{
    public class Level
    {
        /// <summary>
        /// ground
        /// </summary>
        TileMatrix ground;

        /// <summary>
        /// Layer for building your base
        /// </summary>
        TileMatrix buildlayer;
        
        /// <summary>
        /// The current GameState
        /// </summary>
        GameState gameState;

        /// <summary>
        /// MenuBar
        /// </summary>
        BuildingMenuBar mb;

        /// <summary>
        /// The Cursor
        /// </summary>
        public TileCursor Cursor { get; set; }

        /// <summary>
        /// TextureCache
        /// </summary>
        ConcurrentDictionary<string, Texture2D> textureCache;

        /// <summary>
        /// ButtonCooldown variable
        /// </summary>
        int ButtonCooldown = 0;

        /// <summary>
        /// GraphicsDevice
        /// </summary>
        GraphicsDevice gr;

        /// <summary>
        /// Levelmeasurements std = 50
        /// </summary>
        int height = 100, width = 100;

        /// <summary>
        /// Level Camera
        /// </summary>
        public Camera2D camera;

        /// <summary>
        /// GameComponentCollection
        /// </summary>
        private GameComponentCollection components;

        /// <summary>
        /// parent GameContainer
        /// </summary>
        Game parentGame;

        /// <summary>
        /// Loading Screen which is displayed while loading Textures Sounds and generating Stuff
        /// </summary>
        LoadingScreen loading;

        PythonLoader plTest;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="textureCache"></param>
        public Level(ConcurrentDictionary<string, Texture2D> textureCache)
        {
            gameState = GameState.Building;
            this.textureCache = textureCache;
            Cursor = new TileCursor(textureCache, 100, "BuildCursor");
        }

        /// <summary>
        /// Constructor with internal camera init
        /// </summary>
        /// <param name="textureCache"></param>
        /// <param name="components"></param>
        /// <param name="parent"></param>
        public Level(ConcurrentDictionary<string, Texture2D> textureCache, GameComponentCollection components, Game parent) : this(textureCache)
        {
            this.components = components;
            parentGame = parent;
            camera = new Camera2D(parentGame, Cursor);
            components.Add(camera);
            
        }

        /// <summary>
        /// Sets the GraphicDevice for generating plain textures
        /// </summary>
        /// <param name="gr"></param>
        public void SetGraphicDevice(GraphicsDevice gr)
        {
            this.gr = gr;
        }

        /// <summary>
        /// Draws everything with the given SpriteBatch
        /// </summary>
        /// <param name="spritebatch"></param>
        public void Draw(SpriteBatch spritebatch, Camera2D camera)
        {
            switch (gameState)
            {
                case GameState.Building:
                    ground.Draw(spritebatch, camera);
                    buildlayer.Draw(spritebatch, camera);
                    Cursor.Draw(spritebatch, camera);
                    break;
                case GameState.Defending:
                    break;
                case GameState.Loading:
                    break;
                case GameState.Menu:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Draws everthing imoveable (unaffected by camera)
        /// </summary>
        /// <param name="spritebatch"></param>
        /// <param name="camera"></param>
        public void DrawOnScreen(SpriteBatch spritebatch, Camera2D camera = null)
        {
            switch (gameState)
            {
                case GameState.Building:
                    mb.Draw(spritebatch, camera);
                    break;
                case GameState.Defending:
                    break;
                case GameState.Loading:
                    loading.Draw(spritebatch);
                    break;
                case GameState.Menu:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Loads everything
        /// </summary>
        public void Load(ContentManager content)
        {

            textureCache.TryAdd("BaseTexture", content.Load<Texture2D>("Textures\\gras.png"));
            textureCache.TryAdd("BuildCursor", content.Load<Texture2D>("Textures\\RedBorder.png"));
            textureCache.TryAdd("Stone", content.Load<Texture2D>("Textures\\stein.png"));
            textureCache.TryAdd("WoodWall", content.Load<Texture2D>("Textures\\holzwand.png"));
            textureCache.TryAdd("WoodWallCorner", content.Load<Texture2D>("Textures\\holzwandecke.png"));
            textureCache.TryAdd("MenuBar", content.Load<Texture2D>("Textures\\Menüleiste.png"));
            textureCache.TryAdd("MenuBarEnding", content.Load<Texture2D>("Textures\\Menüleistenendung.png"));
            
            // Load Python Scripts here
            //plTest = new PythonLoader(File.ReadAllText(@"C:\Users\Sebastian\Documents\GitHubVisualStudio\InsertNameHere\InsertNameHere\InsertNameHere\Scripts\Test\TestScript.py"), "MathTest");

            Texture2D tex;
            textureCache.TryGetValue("BaseTexture", out tex);
            ground = new TileMatrix(height, width, tex);
            buildlayer = new TileMatrix(Color.Red, height, width, gr);
            mb = new BuildingMenuBar(textureCache);
            mb.SetPosition(200, 200);
            Cursor.Load();
        }

        /// <summary>
        /// Sets the Levelmeasurements. Must be called before Level.Load()
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public void SetLevelMeasurements(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        /// <summary>
        /// Updates Enviroment according to the buttons which were pressed
        /// </summary>
        /// <param name="gametime"></param>
        public void UpdateButtons(GameTime gametime)
        {
            if (ButtonCooldown > 0)
            {
                ButtonCooldown--;
            }
            if (ButtonCooldown <= 0)
            { 
                var LeftStick = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left;
                var RightStick = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right;

                //If the Player presses a button to get Left
                if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed || LeftStick.X <= -.5f || RightStick.X <= -.5f)
                {
                    switch (gameState)
                    {
                        case GameState.Building:
                            if (Cursor.xPosition > 0)
                            {
                                Cursor.SetPosition(Cursor.xPosition - 1, Cursor.yPosition);
                                ButtonCooldown = 10;
                            }
                            break;
                        case GameState.Defending:
                            break;
                        case GameState.Loading:
                            break;
                        case GameState.Menu:
                            break;
                        default:
                            break;
                    }
                }

                //If the Player presses a button to get Right
                if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed || LeftStick.X >= .5f || RightStick.X >= .5f)
                {
                    switch (gameState)
                    {
                        case GameState.Building:
                            if (Cursor.xPosition < width - 1)
                            {
                                Cursor.SetPosition(Cursor.xPosition + 1, Cursor.yPosition);
                                ButtonCooldown = 10;
                            }
                            break;
                        case GameState.Defending:
                            break;
                        case GameState.Loading:
                            break;
                        case GameState.Menu:
                            break;
                        default:
                            break;
                    }
                }

                //If the Player presses a button to get Up
                if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed || LeftStick.Y >= .5f || RightStick.Y >= .5f)
                {
                    switch (gameState)
                    {
                        case GameState.Building:
                            if (Cursor.yPosition > 0)
                            {
                                Cursor.SetPosition(Cursor.xPosition, Cursor.yPosition - 1);
                                ButtonCooldown = 10;
                            }
                            break;
                        case GameState.Defending:
                            break;
                        case GameState.Loading:
                            break;
                        case GameState.Menu:
                            break;
                        default:
                            break;
                    }
                }

                //If the Player presses a button to get Down
                if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed || LeftStick.Y <= -.5f || RightStick.Y <= -.5f)
                {
                    switch (gameState)
                    {
                        case GameState.Building:
                            if (Cursor.yPosition < height - 1)
                            {
                                Cursor.SetPosition(Cursor.xPosition, Cursor.yPosition + 1);
                                ButtonCooldown = 10;
                            }
                            break;
                        case GameState.Defending:
                            break;
                        case GameState.Loading:
                            break;
                        case GameState.Menu:
                            break;
                        default:
                            break;
                    }
                }

                //If the Player presses a button to do something
                if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
                {
                    switch (gameState)
                    {
                        case GameState.Building:
                            Tile t = mb.GetSelected();
                            t.SetPosition(Cursor.Position.X, Cursor.Position.Y);
                            buildlayer.Replace(t, (int)(Cursor.GetPositionInTileMatrix().X), (int)(Cursor.GetPositionInTileMatrix().Y));
                            Logger.Shoot(string.Format("Placed Tile on buildlayer[x = {0}][y = {1}]", (int)(Cursor.GetPositionInTileMatrix().X), (int)(Cursor.GetPositionInTileMatrix().Y)));
                            ButtonCooldown = 10;
                            break;
                        case GameState.Defending:
                            break;
                        case GameState.Loading:
                            break;
                        case GameState.Menu:
                            break;
                        default:
                            break;
                    }
                }
            }

            //Update only specific components
            switch (gameState)
            {
                case GameState.Building:
                    mb.Update(gametime);
                    break;
                case GameState.Defending:
                    break;
                case GameState.Loading:
                    break;
                case GameState.Menu:
                    break;
                default:
                    break;
            }
        }

        public void UpdateKI(GameTime gametime)
        {
            #region Testregion for Python performance
            if (plTest != null)
            {
                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
                parameters.Add("N", 100);
                plTest.Execute(parameters);
                
            }
            #endregion
        }

        public void UpdateSoundQueue()
        {

        }
    }
}
