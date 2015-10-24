using InsertNameHere.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        Dictionary<string, Texture2D> textureCache;

        /// <summary>
        /// ButtonCooldown variable
        /// </summary>
        int ButtonCooldown = 0;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="textureCache"></param>
        public Level(Dictionary<string, Texture2D> textureCache)
        {
            gameState = GameState.Building;
            this.textureCache = textureCache;
            Cursor = new TileCursor(textureCache, 100, "BuildCursor");
        }

        /// <summary>
        /// Draws everything with the given SpriteBatch
        /// </summary>
        /// <param name="spritebatch"></param>
        public void Draw(SpriteBatch spritebatch)
        {
            ground.Draw(spritebatch);
            if (gameState == GameState.Building)
            {
                Cursor.Draw(spritebatch);
                mb.Draw(spritebatch);
            }
        }

        /// <summary>
        /// Loads everything
        /// </summary>
        public void Load()
        {
            Texture2D tex;
            textureCache.TryGetValue("BaseTexture", out tex);
            ground = new TileMatrix(40, 40, tex);
            mb = new BuildingMenuBar(textureCache);
            mb.SetPosition(200, 200);
            Cursor.Load();
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
                    Cursor.SetPosition(Cursor.xPosition - 1, Cursor.yPosition);
                    ButtonCooldown = 10;
                }
                if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed || LeftStick.X >= .5f || RightStick.X >= .5f)
                {
                    Cursor.SetPosition(Cursor.xPosition + 1, Cursor.yPosition);
                    ButtonCooldown = 10;
                }
                if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed || LeftStick.Y >= .5f || RightStick.Y >= .5f)
                {
                    Cursor.SetPosition(Cursor.xPosition, Cursor.yPosition - 1);
                    ButtonCooldown = 10;
                }
                if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed || LeftStick.Y <= -.5f || RightStick.Y <= -.5f)
                {
                    Cursor.SetPosition(Cursor.xPosition, Cursor.yPosition + 1);
                    ButtonCooldown = 10;
                }
            }
        }
    }
}
