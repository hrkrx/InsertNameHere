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

        public void Draw(SpriteBatch spritebatch)
        {
            Rectangle r = new Rectangle((int)(xPosition), (int)(yPosition), xSize, ySize);
            spritebatch.Draw(texture, r, Color.White);
        }
    }
}