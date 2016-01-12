using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.Collections.Concurrent;

namespace InsertNameHere.GameObjects.Map
{
    public class TileCursor : IFocusable
    {
        /// <summary>
        /// Initial Position (0, 0)
        /// </summary>
        public int xPosition;
        public int yPosition;

        /// <summary>
        /// Tile which serves as Cursor
        /// </summary>
        Tile Cursor;

        /// <summary>
        /// TextureCache 
        /// </summary>
        ConcurrentDictionary<string, Texture2D> textureCache;
        int size;
        string key;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="textureCache">TextureCache</param>
        /// <param name="size">size</param>
        /// <param name="key">key, which was used to load the Texture into the cache</param>
        public TileCursor (ConcurrentDictionary<string, Texture2D> textureCache, int size, string key)
        {
            this.textureCache = textureCache;
            this.size = size;
            this.key = key;
        }

        /// <summary>
        /// Loads everything needed for the Cursor to be used
        /// </summary>
        public void Load()
        {
            Cursor = new Tile(textureCache, size, key);
        }

        /// <summary>
        /// Position is needed by IFocusable
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return new Vector2(xPosition * 100, yPosition * 100);
            }
        }

        /// <summary>
        /// Draws the Texture
        /// </summary>
        /// <param name="spritebatch"></param>
        public void Draw(SpriteBatch spritebatch, Camera2D camera)
        {
            Cursor.Draw(spritebatch, camera);
        }

        /// <summary>
        /// Sets the position in TileCoords (x * 100 = px)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        internal void SetPosition(int x, int y)
        {
            xPosition = x;
            yPosition = y;
            Cursor.SetPosition(x * 100, y * 100);
        }

        /// <summary>
        /// returns the Position in TileMatrix-conform coords
        /// </summary>
        /// <returns></returns>
        public Vector2 GetPositionInTileMatrix()
        {
            Vector2 res;
            res = new Vector2(xPosition, yPosition);
            return res;
        }
    }
}
