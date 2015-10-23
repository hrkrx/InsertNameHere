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
        Tile mbEnd, mbBegin, mbMiddle;
        public BuildingMenuBar(Dictionary<string, Texture2D> textureCache)
        {
            this.textureCache = textureCache;
            position = new Vector2(0, 0);
            
            Texture2D mbB;
            textureCache.TryGetValue("MenuBarEnding", out mbB);
            mbBegin = new Tile(mbB, 120);
            mbEnd = new Tile(mbB, 120);
            mbEnd.Rotate(180);
            Texture2D mbM;
            textureCache.TryGetValue("MenuBar", out mbM);
            mbMiddle = new Tile(mbM, 120);
            buildthings.Add(new Tile(textureCache, 100, "WoodWall"));
            buildthings.Add(new Tile(textureCache, 100, "WoodWallCorner"));
        }

        public void SetPosition(float x, float y)
        {
            position = new Vector2(x, y);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            int c = 0;
            mbBegin.SetPosition(position.X, position.Y);
            mbBegin.Draw(spritebatch);
            for (int i = 1; i <= buildthings.Count; i++)
            {
                mbMiddle.SetPosition(position.X + i * 120, position.Y);
                mbMiddle.Draw(spritebatch);
                c = i;
            }
            mbEnd.SetPosition(position.X + c * 120, position.Y - 120);
            mbEnd.Draw(spritebatch);
        }

        public void Update(GameTime gametime)
        {

        }
    }
}
