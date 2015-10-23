using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace InsertNameHere
{
    public class TileCursor
    {
        public int xPosition;
        public int yPosition;
        Tile Cursor;

        public TileCursor (Dictionary<string, Texture2D> textureCache, int size, string key)
        {
            Cursor = new Tile(textureCache, size, key);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            Cursor.Draw(spritebatch);
        }

        internal void SetPosition(int x, int y)
        {
            xPosition = x;
            yPosition = y;
            Cursor.SetPosition(x * 100, y * 100);
        }
    }
}
