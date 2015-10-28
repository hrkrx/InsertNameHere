using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsertNameHere.GameObjects
{
    public class AnimatedTexture2D
    {
        Texture2D baseTexture;
        public int animationFlowNumber = 4;
        public int step = 0;
        int width, height;
        float _elapsed_time = 0.0f;
        float animationSpeed = 200f;

        public AnimatedTexture2D(Texture2D tex, int width, int height)
        {
            baseTexture = tex;
            this.width = width;
            this.height = height;
        }

        public AnimatedTexture2D(ConcurrentDictionary<string, Texture2D> textureCache, string key, int width, int height)
        {
            textureCache.TryGetValue(key, out baseTexture);
            this.width = width;
            this.height = height;
        }

        public void Update(GameTime gameTime)
        {
            _elapsed_time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            // 1 Step has passed
            if (_elapsed_time >= animationSpeed)
            {
                UpdateAnimation();
                _elapsed_time = 0;
            }
        }

        private void UpdateAnimation()
        {
            if (step < animationFlowNumber - 1)
            {
                step++;
            }
            else
            {
                step = 0;
            }
        }
    }
}
