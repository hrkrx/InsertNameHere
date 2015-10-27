using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace InsertNameHere
{
    public class BuildingMenuBar
    {
        /// <summary>
        /// A List with available Tiles
        /// </summary>
        List<Tile> buildthings = new List<Tile>();

        /// <summary>
        /// selected Tile
        /// </summary>
        int selected;
        Tile selector;

        /// <summary>
        /// TextureCache
        /// </summary>
        ConcurrentDictionary<string, Texture2D> textureCache;

        /// <summary>
        /// position
        /// </summary>
        Vector2 position;

        /// <summary>
        /// Tiles used for the Menubackground
        /// </summary>
        Tile mbEnd, mbBegin, mbMiddle;

        /// <summary>
        /// ButtonCooldown variable
        /// </summary>
        int ButtonCooldown = 0;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="textureCache"></param>
        public BuildingMenuBar(ConcurrentDictionary<string, Texture2D> textureCache)
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
            buildthings.Add(new Tile(textureCache, 100, "Stone"));
            selector = new Tile(textureCache, 100, "BuildCursor");
        }

        /// <summary>
        /// returns a clone of the selected Tile
        /// </summary>
        /// <returns></returns>
        public Tile GetSelected()
        {
            Tile res = buildthings[selected].Clone() as Tile;
            return res;
        }

        /// <summary>
        /// Set the position 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetPosition(float x, float y)
        {
            position = new Vector2(x, y);
        }

        /// <summary>
        /// Draw the Menu (including the buildthings)
        /// </summary>
        /// <param name="spritebatch"></param>
        public void Draw(SpriteBatch spritebatch, Camera2D camera)
        {
            int c = 0;
            mbBegin.SetPosition(position.X, position.Y);
            mbBegin.Draw(spritebatch, camera);
            for (int i = 1; i <= buildthings.Count; i++)
            {

                mbMiddle.SetPosition(position.X + i * 120, position.Y);
                mbMiddle.Draw(spritebatch, camera);
                buildthings[i - 1].SetPosition(position.X + i * 120, position.Y);
                buildthings[i - 1].Draw(spritebatch, camera);
                c = i;
            }
            mbEnd.SetPosition(position.X + c * 120 + 120, position.Y);
            mbEnd.Draw(spritebatch, camera);
            selector.SetPosition(buildthings[selected].xPosition, buildthings[selected].yPosition);
            selector.Draw(spritebatch, camera);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gametime"></param>
        public void Update(GameTime gametime)
        {

            if (ButtonCooldown > 0)
            {
                ButtonCooldown--;
            }
            if (ButtonCooldown <= 0)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.RightShoulder == ButtonState.Pressed)
                {
                    if (selected < buildthings.Count - 1)
                    {
                        selected++;
                        
                    }else
                    {
                        selected = 0;
                    }
                    ButtonCooldown = 10;
                }

                if (GamePad.GetState(PlayerIndex.One).Buttons.LeftShoulder == ButtonState.Pressed)
                {
                    if (selected > 0)
                    {
                        selected--;
                    }
                    else
                    {
                        selected = buildthings.Count - 1;
                    }
                    ButtonCooldown = 10;
                }

                if (GamePad.GetState(PlayerIndex.One).Triggers.Left >= 0.5f)
                {
                    foreach (var item in buildthings)
                    {
                        item.Rotate(-90);
                    }
                    ButtonCooldown = 10;
                }

                if (GamePad.GetState(PlayerIndex.One).Triggers.Right >= 0.5f)
                {
                    foreach (var item in buildthings)
                    {
                        item.Rotate(90);
                    }
                    ButtonCooldown = 10;
                }
            }
        }
    }
}
