using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsertNameHere
{
    public class SolidColorTile : Tile
    {
        public SolidColorTile (Color color, GraphicsDevice gr)
            : base()
        {
            SetTexture(new SolidColorTexture2D(gr, color));
        }
    }
}
