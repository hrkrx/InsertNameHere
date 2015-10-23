using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace InsertNameHere
{
    public class BuildingMenuBar
    {
        List<Tile> buildthings = new List<Tile>();
        Tile selected;
        Dictionary<string, Texture2D> textureCache;
        Vector2 position;

        public BuildingMenuBar(Dictionary<string, Texture2D> textureCache)
        {
            this.textureCache = textureCache;
            position = new Vector2(0, 0);

        }

        public void Draw(SpriteBatch spritebatch)
        {
            Tile mbEnd, mbBegin, mbMiddle;
            
        }

    }
}
