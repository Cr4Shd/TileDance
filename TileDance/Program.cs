using System;
using System.Runtime.CompilerServices;
using TileDance.Map;
using TileDance.Village;

namespace TileDance
{
    class Program
    {
        static void Main(string[] args)
        {
            #region TheAnvil!
            TestStaticMainMap.FillMainMaip();
            TileHandler.InitalizeStaticDelegates();

            //Hardcoded!
            TileHandler.GetNeighborTile(TestStaticMainMap.MapTilePool[0, 0]);
            
            var x = GetVillagesOnMap();

            foreach (var village in x)
            {
                village.GetTradePartners();
                village.GetProxRessources();
            }
            VillageProgressHandler.CalculateVillageProgress();
            //y.OnTileCallsForScan(y);
            #endregion
        }

        #region test
        /// <summary>
        /// Takes no Para and returns a list of all villages on the Map
        /// </summary>
        public static List<Village.Village> GetVillagesOnMap()
        {
            List<Village.Village> e = new List<Village.Village>();

            int x = 0;
            Village.Village? vil = null;
            foreach (var item in TestStaticMainMap.MapTilePool)
            {
                if (item.VillageOnTile != null)
                {
                    x += 1;
                    e.Add(item.VillageOnTile);

                    if (vil == null)
                    {
                        vil = item.VillageOnTile;
                    }
                }
            }
            Console.WriteLine($"Auf der Map sind {x} Dörfer");

            return e;
        }
        public static MapTile GetTileOfVillage(Village.Village vil)
        {
            int x, y;
            x = vil.PosX; y = vil.PosY;
            var tile = TestStaticMainMap.MapTilePool[x, y];
            return tile;
        }
        #endregion
    }
}