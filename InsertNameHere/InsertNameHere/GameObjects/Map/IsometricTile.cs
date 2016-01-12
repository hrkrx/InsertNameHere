using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsertNameHere.GameObjects.Map
{
    public class IsometricTile : Tile
    {
        public int isometricHeightOffset;
        public RotationMatrix2d rotationMatrix;

        public IsometricTile(Texture2D texture, int size, int heightOffset)
            :base(texture, size)
        {
            rotationMatrix = new RotationMatrix2d(-45);
            isometricHeightOffset = heightOffset;
        }

        public override void Draw(SpriteBatch spritebatch, Camera2D camera = null)
        {
            Vector2 r = rotationMatrix.rotate(new Vector2((int)(xPosition), (int)(yPosition)));
            if (camera == null || camera.IsInView(r, texture))
            {
                spritebatch.Draw(texture, r, null, Color.White, 0, new Vector2(texture.Width / 2, texture.Height / 2), 1, SpriteEffects.None, 0);
            }
        }
    }
}
