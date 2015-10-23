using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace InsertNameHere
{
    public class TileCursor : IFocusable
    {
        public int xPosition;
        public int yPosition;
        Tile Cursor;
        Dictionary<string, Texture2D> textureCache;
        int size;
        string key;

        public TileCursor (Dictionary<string, Texture2D> textureCache, int size, string key)
        {
            this.textureCache = textureCache;
            this.size = size;
            this.key = key;
        }

        public void Load()
        {
            Cursor = new Tile(textureCache, size, key);
        }

        public Vector2 Position
        {
            get
            {
                return new Vector2(xPosition * 100, yPosition * 100);
            }
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
