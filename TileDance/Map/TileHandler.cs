using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TileDance.Village;
using TileDance.Village.VillageEventArgs;
using static TileDance.Map.MapTile;

namespace TileDance.Map
{
    static class TileHandler
    {
        
        /// <summary>
        /// Entrymethod for the general approxscan of an village
        /// </summary>
        /// <param name="tile"></param>
        private static void MapTile_CallForScan(MapTile tile)
        {
            var x = GetNeighborTile(tile);
        }
      
        
        /// <summary>
        /// Gets a Maptile as object - returns an array of the sorrounding maptiles
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        public static MapTile[] GetNeighborTile(MapTile tile)
        {
            var x = tile.TileXCoord; var y = tile.TileYCoord;
            MapTile[] mapTiles = new MapTile[8];

            for (int i = 0; i < mapTiles.Length; i++)
            {
                try
                {
                    switch (i)
                    {
                        case 0:
                            mapTiles[i] = TestStaticMainMap.MapTilePool[x - 1, y - 1];
                            break;
                        case 1:
                            mapTiles[i] = TestStaticMainMap.MapTilePool[x, y - 1];
                            break;
                        case 2:
                            mapTiles[i] = TestStaticMainMap.MapTilePool[x + 1, y - 1];
                            break;
                        case 3:
                            mapTiles[i] = TestStaticMainMap.MapTilePool[x - 1, y];
                            break;
                        case 4:
                            mapTiles[i] = TestStaticMainMap.MapTilePool[x + 1, y];
                            break;
                        case 5:
                            mapTiles[i] = TestStaticMainMap.MapTilePool[x - 1, y + 1];
                            break;
                        case 6:
                            mapTiles[i] = TestStaticMainMap.MapTilePool[x, y + 1];
                            break;
                        case 7:
                            mapTiles[i] = TestStaticMainMap.MapTilePool[x + 1, y + 1];
                            break;

                    }
                }
                catch (Exception e)
                {

                }
            }
            return mapTiles;
        }
        #region VillageLogik
        
        
        /// <summary>
        /// Gets an array of maptiles and checks if there are any villages in the 8 sorrounding tiles
        /// </summary>
        /// <param name="maptile"></param>
        /// <returns></returns>
        public static IEnumerable<Village.Village> CheckForVillage(MapTile[] maptile)
        {
            List<Village.Village> listVil = new List<Village.Village>();

            foreach(MapTile tile in maptile)
            {
                if (tile != null && tile.VillageOnTile != null)
                {
                    listVil.Add(tile.VillageOnTile);
                }
                else
                {
                    continue;
                }
            }
            return listVil;
        }
        /// <summary>
        /// Gets an array of maptiles and checks if there are any ressources in the 8 sorrounding tiles
        /// </summary>
        /// <param name="maptile"></param>
        /// <returns></returns>
        public static IEnumerable<TileRessources> ScanForResources(MapTile[] maptile)
        {
            List<TileRessources> resourceList = new List<TileRessources>();

            foreach (MapTile tile in maptile)
            {
                if(tile != null && tile._TileRessources != null)
                {
                    resourceList.Add(tile._TileRessources);
                }
                else
                {
                    continue;
                }
            }
            return resourceList;
        }
        #endregion
        
        /// <summary>
        /// Entrymethod for the Tradepartner Scan of a village
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private static VillageScanEventArgs VillageScanTradePartners(VillageScanEventArgs e)
        {
            var sendingVillage = (Village.Village)e.Sender;
            var x = TestStaticMainMap.MapTilePool[sendingVillage.PosX, sendingVillage.PosY];
            var y = GetNeighborTile(x);
            var x1 = CheckForVillage(y);
            e.ResultVillage = x1;
            return e;
        }
        /// <summary>
        /// Entrymethod for the ResourceScan of a village
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private static RessourceScanEventArgs VillageScanRessources(RessourceScanEventArgs e)
        {
            var sendingVillage = (Village.Village)e.Sender;
            var x = TestStaticMainMap.MapTilePool[sendingVillage.PosX, sendingVillage.PosY];
            var y = GetNeighborTile(x);
            var x1 = ScanForResources(y); // Neue Methode für Ressourcen
            e.Ressources = x1;
            return e;
        }

        /// <summary>
        /// Event <-> Method Linking
        /// </summary>
        public static void InitalizeStaticDelegates()
        {
            Village.Village.CallForNeighborScan += VillageScanTradePartners;
            Village.Village.CallForResourceScan += VillageScanRessources;
            MapTile.CallForScan += MapTile_CallForScan;
        }
      
    }
    
}
