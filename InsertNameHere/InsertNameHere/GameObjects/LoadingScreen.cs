using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsertNameHere.GameObjects
{
    public class LoadingScreen
    {
        public Texture2D background;
        public Tile loadingTile;
        public Vector2 screen;
        public List<string> textures;
        public List<string> sounds;
        GraphicsDevice g;
        int max;
        int current;

        public LoadingScreen(Texture2D bg, float screenx, float screeny, GraphicsDevice g)
        {
            this.g = g;
            background = bg;
            screen = new Vector2(screenx, screeny);
            loadingTile = new SolidColorTile(Color.Red, g);
        }

        public void Update(int curr, int max)
        {
            current = curr;
            this.max = max;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(background, new Rectangle((int)(screen.X - background.Bounds.Width), (int)(screen.Y - background.Bounds.Height), background.Bounds.Width, background.Bounds.Height), Color.White);
            int progress = ((current / max) * 100) % 10;
            for (int i = 0; i < progress; i++)
            {
                loadingTile.SetPosition(i * 110, screen.Y - 100);
                loadingTile.Draw(spritebatch);
            }
        }

    }
}
