using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace InsertNameHere.GameObjects.Map
{
    public class TileMatrix
    {
        Tile[][] matrix;


        public TileMatrix(Color color, int height, int width, GraphicsDevice gr)
        {
            matrix = new Tile[height][];
            for (int i = 0; i < height; i++)
            {
                matrix[i] = new Tile[width];
                for (int j = 0; j < width; j++)
                {
                    SolidColorTile tmpTile = new SolidColorTile(color, gr);
                    tmpTile.SetPosition(j * 100, i * 100);
                    matrix[i][j] = tmpTile;
                }
            }
        }

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

        public void Initialize(int height, int width, Texture2D baseTexture)
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

        public void Replace(Tile tile, int x, int y)
        {
            matrix[y][x] = tile;
        }

        public void Draw (SpriteBatch spritebatch, Camera2D camera)
        {
            foreach (var item in matrix)
            {
                foreach (var tile in item)
                {
                    tile.Draw(spritebatch, camera);
                }
            }
        }
    }
}
