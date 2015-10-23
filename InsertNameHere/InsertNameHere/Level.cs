using InsertNameHere.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace InsertNameHere
{
    public class Level
    {
        TileMatrix ground;
        GameState gameState;
        BuildingMenuBar mb;
        TileCursor Cursor;

        public Level(Dictionary<string, Texture2D> textureCache)
        {
            gameState = GameState.Building;
            Texture2D tex;
            textureCache.TryGetValue("BaseTexture", out tex);
            ground = new TileMatrix(100, 100, tex);
            mb = new BuildingMenuBar(textureCache);
            mb.SetPosition(200, 200);
            Cursor = new TileCursor(textureCache, 100, "BuildCursor");
        }

        public void Draw(SpriteBatch spritebatch)
        {
            ground.Draw(spritebatch);
            if (gameState == GameState.Building)
            {
                Cursor.Draw(spritebatch);
                mb.Draw(spritebatch);
            }
        }

        public void UpdateButtons(GameTime gametime)
        {
            var LeftStick = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left;
            var RightStick = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right;

            if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed || LeftStick.X <= -.5f || RightStick.X <= -.5f)
            {
                Cursor.SetPosition(Cursor.xPosition - 1, Cursor.yPosition);
            }
            if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed || LeftStick.X >= .5f || RightStick.X >= .5f)
            {
                Cursor.SetPosition(Cursor.xPosition + 1, Cursor.yPosition);
            }
            if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed || LeftStick.Y >= .5f || RightStick.Y >= .5f)
            {
                Cursor.SetPosition(Cursor.xPosition, Cursor.yPosition - 1);
            }
            if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed || LeftStick.Y <= -.5f || RightStick.Y <= -.5f)
            {
                Cursor.SetPosition(Cursor.xPosition, Cursor.yPosition + 1);
            }
        }
    }
}
