using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsertNameHere.GameObjects.Map
{
    public class SolidColorTexture2D : Texture2D
    {
        private Color _color;
        // Gets or sets the color used to create the texture
        public Color Color
        {
            get { return _color; }
            set
            {
                if (value != _color)
                {
                    _color = value;
                    SetData(new Color[] { _color });
                }
            }
        }


        public SolidColorTexture2D(GraphicsDevice graphicsDevice)
            : base(graphicsDevice, 1, 1)
        {
            //default constructor
        }
        public SolidColorTexture2D(GraphicsDevice graphicsDevice, Color color)
            : base(graphicsDevice, 1, 1)
        {
            Color = color;
        }
    }
}
