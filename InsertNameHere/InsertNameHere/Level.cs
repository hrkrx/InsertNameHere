using InsertNameHere.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace InsertNameHere
{
    public class Level
    {
        TileMatrix ground;
        GameState gameState;
        BuildingMenuBar mb;

        public Level(Dictionary<string, Texture2D> textureCache)
        {
            gameState = GameState.Building;
            Texture2D tex;
            textureCache.TryGetValue("BaseTexture", out tex);
            ground = new TileMatrix(100, 100, tex);
            mb = new BuildingMenuBar(textureCache);
            mb.SetPosition(200, 200);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            ground.Draw(spritebatch);
            if (gameState == GameState.Building)
            {
                mb.Draw(spritebatch);
            }
        }

        public void Update(GameTime gametime)
        {

        }
    }
}
