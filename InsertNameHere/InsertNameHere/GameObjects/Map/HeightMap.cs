using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsertNameHere.GameObjects.Map
{
    public class HeightMap
    {
        int[][] hMap;

        public HeightMap(int width, int height)
        {
            hMap = new int[width][];
            for (int i = 0; i < hMap.Count(); i++)
            {
                hMap[i] = new int[height];
            }
        }

        public int get(int x, int y)
        {
            return hMap[x][y];
        }
        public void set(int x, int y, int value)
        {
            hMap[x][y] = value;
        }
    }
}
