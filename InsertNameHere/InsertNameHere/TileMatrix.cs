using Microsoft.Xna.Framework.Graphics;

namespace InsertNameHere
{
    public class TileMatrix
    {
        Tile[][] matrix;
        
        public TileMatrix (int height, int width, Texture2D baseTexture)
        {
            matrix = new Tile[height][];
            for (int i = 0; i < height; i++)
            {
                matrix[i] = new Tile[width];
                for (int j = 0; j < width; j++)
                {
                    Tile tmpTile = new Tile(baseTexture);
                    tmpTile.SetPosition(j * 100, i * 100);
                    matrix[i][j] = tmpTile;
                }
            }
        }

        public void Draw (SpriteBatch spritebatch)
        {
            foreach (var item in matrix)
            {
                foreach (var tile in item)
                {
                    tile.Draw(spritebatch);
                }
            }
        }
    }
}
