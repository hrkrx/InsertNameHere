using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsertNameHere.GameObjects.Map
{
    public class RotationMatrix2d
    {
        Vector2 col1;
        Vector2 col2;

        public RotationMatrix2d(int degrees)
        {
            col1 = new Vector2((float)Math.Cos(degrees / 180 * Math.PI), (float)(-1 * Math.Sin(degrees / 180 * Math.PI)));
            col2 = new Vector2((float)Math.Sin(degrees / 180 * Math.PI), (float)Math.Cos(degrees / 180 * Math.PI));
        }

        public Vector2 rotate(Vector2 v1)
        {
            Vector2 res = new Vector2((v1.X * col1.X) + (v1.X * col2.X), (v1.Y * col1.Y) + (v1.Y * col2.Y));
            return res;
        }
    }
}
