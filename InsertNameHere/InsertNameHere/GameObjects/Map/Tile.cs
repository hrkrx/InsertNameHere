using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace InsertNameHere
{
    public class Tile : ICloneable
    {
        /// <summary>
        /// Texture which gets drawn
        /// </summary>
        public Texture2D texture = null;

        /// <summary>
        /// Exact size of the Texture
        /// </summary>
        public int xSize = 100;
        public int ySize = 100;

        /// <summary>
        /// Initial Position
        /// </summary>
        public double xPosition = 0;
        public double yPosition = 0;

        /// <summary>
        /// initial Rotation
        /// </summary>
        public int rotation = 0;
        
        public Tile()
        {
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="texture">Texture with standart size (100x100)</param>
        public Tile (Texture2D texture)
        {
            if (texture.Bounds.Height == ySize && texture.Bounds.Width == xSize)
            {
                this.texture = texture;
            }
            else
            {
                throw new Exception("Wrong texturesize!");
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="texture">Textur with given size</param>
        /// <param name="size">size</param>
        public Tile(Texture2D texture, int size)
        {
            xSize = ySize = size;
            if (texture.Bounds.Height == ySize && texture.Bounds.Width == xSize)
            {
                this.texture = texture;
            }
            else
            {
                throw new Exception("Wrong texturesize!");
            }
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="textureCache">TextureCache</param>
        /// <param name="size">size</param>
        /// <param name="key">key, which was used to load the Texture into the cache</param>
        public Tile(ConcurrentDictionary<string, Texture2D> textureCache, int size, string key)
        {
            Texture2D texture;
            textureCache.TryGetValue(key, out texture);
            xSize = ySize = size;
            if (texture.Bounds.Height == ySize && texture.Bounds.Width == xSize)
            {
                this.texture = texture;
            }
            else
            {
                throw new Exception("Wrong texturesize!");
            }
        }

        public void SetTexture(Texture2D texture)
        {
            this.texture = texture;
        }

        /// <summary>
        /// Set the Size afterwards (no use yet)
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public void SetSize(int height, int width)
        {
            xSize = width;
            ySize = height;
        }

        /// <summary>
        /// Set the Position where the Texture gets drawn
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetPosition(double x, double y)
        {
            xPosition = x;
            yPosition = y;
        }

        /// <summary>
        /// Sets the rotation
        /// </summary>
        /// <param name="degrees"></param>
        public void Rotate(int degrees)
        {
            rotation += degrees;
            if (rotation > 360)
            {
                rotation -= 360;
            }
        }

        /// <summary>
        /// Draws the Texture with the given SpriteBatch
        /// </summary>
        /// <param name="spritebatch"></param>
        public virtual void Draw(SpriteBatch spritebatch, Camera2D camera = null)
        {
            Vector2 r = new Vector2((int)(xPosition), (int)(yPosition));
            if (camera == null || camera.IsInView(r, texture))
            {
                spritebatch.Draw(texture, r, null, Color.White, (float)(Math.PI * 0.5 * (rotation / 90)), new Vector2(texture.Width / 2, texture.Height / 2), 1, SpriteEffects.None, 0);

            }
        }

        /// <summary>
        /// Returns a new object with equal attributes
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Tile res = new Tile(texture, xSize);
            res.Rotate(rotation);
            res.SetPosition(xPosition, yPosition);
            return res;
        }
    }
}