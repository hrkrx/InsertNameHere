using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace InsertNameHere
{
    public class Level
    {
        TileMatrix ground;

        public Level(Dictionary<string, Texture2D> textureCache)
        {
            Texture2D tex;
            textureCache.TryGetValue("BaseTexture", out tex);
            ground = new TileMatrix(100, 100, tex);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            ground.Draw(spritebatch);
        }
    }
}
