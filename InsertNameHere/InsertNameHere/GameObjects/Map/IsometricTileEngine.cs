using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsertNameHere.GameObjects.Map
{
    public class IsometricTileEngine
    {
        TileMatrix[] enviroment;
        TileMatrix[] decoration;
        TileMatrix[] buildlayer;

        HeightMap hMap;

        static public int TileWidth = 64;
        static public int TileHeight = 64;
        static public int HeightTileOffset = 32;

        public IsometricTileEngine(int lvlWidth, int lvlHeight)
        {
            enviroment = new TileMatrix[3];
            enviroment[0] = new TileMatrix(TileHeight - HeightTileOffset, TileWidth, null);
            enviroment[1] = new TileMatrix(TileHeight - HeightTileOffset, TileWidth, null);
            enviroment[2] = new TileMatrix(TileHeight - HeightTileOffset, TileWidth, null);

            decoration = new TileMatrix[3];
            decoration[0] = new TileMatrix(TileHeight - HeightTileOffset, TileWidth, null);
            decoration[1] = new TileMatrix(TileHeight - HeightTileOffset, TileWidth, null);
            decoration[2] = new TileMatrix(TileHeight - HeightTileOffset, TileWidth, null);

            buildlayer = new TileMatrix[3];
            buildlayer[0] = new TileMatrix(TileHeight - HeightTileOffset, TileWidth, null);
            buildlayer[1] = new TileMatrix(TileHeight - HeightTileOffset, TileWidth, null);
            buildlayer[2] = new TileMatrix(TileHeight - HeightTileOffset, TileWidth, null);

            hMap = new HeightMap(lvlWidth, lvlHeight);
        }

        public void Draw(SpriteBatch spritebatch, Camera2D camera)
        {

        }

    }
}
