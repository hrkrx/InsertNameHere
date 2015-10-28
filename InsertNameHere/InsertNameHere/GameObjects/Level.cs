using InsertNameHere.Controller;
using InsertNameHere.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Concurrent;
using System.Collections.Generic;

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
        /// 
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
            ground.Draw(spritebatch, camera);
            buildlayer.Draw(spritebatch, camera);
            if (gameState == GameState.Building)
            {
                Cursor.Draw(spritebatch, camera);
            }
        }

        /// <summary>
        /// Draws everthing imoveable
        /// </summary>
        /// <param name="spritebatch"></param>
        /// <param name="camera"></param>
        public void DrawOnScreen(SpriteBatch spritebatch, Camera2D camera = null)
        {
            if (gameState == GameState.Building)
            {
                mb.Draw(spritebatch, camera);
            }
        }
        
        /// <summary>
        /// Loads everything
        /// </summary>
        public void Load()
        {
            
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
                if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed || LeftStick.X <= -.5f || RightStick.X <= -.5f)
                {
                    if (Cursor.xPosition > 0)
                    {
                        Cursor.SetPosition(Cursor.xPosition - 1, Cursor.yPosition);
                        ButtonCooldown = 10;
                    }
                }
                if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed || LeftStick.X >= .5f || RightStick.X >= .5f)
                {
                    if (Cursor.xPosition < width - 1)
                    {
                        Cursor.SetPosition(Cursor.xPosition + 1, Cursor.yPosition);
                        ButtonCooldown = 10;
                    }
                }
                if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed || LeftStick.Y >= .5f || RightStick.Y >= .5f)
                {
                    if (Cursor.yPosition > 0)
                    {
                        Cursor.SetPosition(Cursor.xPosition, Cursor.yPosition - 1);
                        ButtonCooldown = 10;
                    }
                }
                if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed || LeftStick.Y <= -.5f || RightStick.Y <= -.5f)
                {
                    if (Cursor.yPosition < height - 1)
                    {
                        Cursor.SetPosition(Cursor.xPosition, Cursor.yPosition + 1);
                        ButtonCooldown = 10;
                    }
                }
                if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
                {
                    Tile t = mb.GetSelected();
                    t.SetPosition(Cursor.Position.X, Cursor.Position.Y);
                    buildlayer.Replace(t, (int)(Cursor.GetPositionInTileMatrix().X), (int)(Cursor.GetPositionInTileMatrix().Y));
                    Logger.Shoot(string.Format("Placed Tile on buildlayer[x = {0}][y = {1}]", (int)(Cursor.GetPositionInTileMatrix().X), (int)(Cursor.GetPositionInTileMatrix().Y)));
                    ButtonCooldown = 10;
                }
            }
            mb.Update(gametime);
        }
    }
}
