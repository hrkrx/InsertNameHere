using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace InsertNameHere
{
    public class Tile
    {
        private Texture2D texture = null;

        public int xSize = 100;
        public int ySize = 100;

        public double xPosition = 0;
        public double yPosition = 0;

        public int rotation = 0;

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

        public Tile(Texture2D texture, int size)
        {
            xSize = ySize = size;
        }
        

        public void SetSize(int height, int width)
        {
            xSize = width;
            ySize = height;
        }

        public void SetPosition(double x, double y)
        {
            xPosition = x;
            yPosition = y;
        }

        public void Rotate(int degrees)
        {
            rotation += degrees;
            if (rotation > 360)
            {
                rotation -= 360;
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            Vector2 r = new Vector2((int)(xPosition), (int)(yPosition));
            spritebatch.Draw(texture, r, null, Color.White, (float)(Math.PI * 0.5 * (rotation / 90)), new Vector2(texture.Width, texture.Height), 1, SpriteEffects.None, 0);
        }
    }
}