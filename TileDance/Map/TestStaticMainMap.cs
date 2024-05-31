using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileDance.Map
{
    static class TestStaticMainMap
    {
        public static MapTile[,]? MapTilePool {  get; set; }
        
        public static void FillMainMaip()
        {
            MapTilePool = new MapTile[25, 25];
            SpawnTiles();
        }
        private static void SpawnTiles()
        {
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    MapTilePool[i, j] = new MapTile(i,j);
                }
            }
        }
    }
}
