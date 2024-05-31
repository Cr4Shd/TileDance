using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileDance.Village
{
    static class VillageProgressHandler
    {
        public static Dictionary<Guid, Village> GlobalVillageRegister = new();

        public static void RegisterVillage(Village village)
        {
            GlobalVillageRegister.Add(village.VillageID, village);
        }
        public static void CalculateVillageProgress()
        {
            foreach (var kvp in GlobalVillageRegister)
            {
                var village = kvp.Value;
                CalculatePopulation(village);
                CalculateGoldProgress(village);
            }
        }


        public static double CalculateGoldProgress(Village village)
        {
            var res = village.TradePartner.Count * village.TileRessources.Count / village.Popul;
            Console.WriteLine($"Das Dorf {village.Name} hat nun {res} Gold dazu bekommen!");
            return res;
        }
        public static double CalculatePopulation(Village village)
        {
            var res = village.Popul * village.FoodRations / 4;
            return res;
        }
    }
}
