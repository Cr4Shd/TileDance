using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileDance.Enties;
using TileDance.Map;
using TileDance.Village.VillageEventArgs;

namespace TileDance.Village
{
    class Village : IVillage
    {
       



        public delegate VillageScanEventArgs VillagesCallsForNeighScan(VillageScanEventArgs e);
        public static event VillagesCallsForNeighScan CallForNeighborScan;

        public delegate RessourceScanEventArgs VillageCallsForRessourceScan(RessourceScanEventArgs e);
        public static event VillageCallsForRessourceScan CallForResourceScan;




        public double Popul { get; set; }
        public Villager[] _Villagers { get; set; }
        public List<Village> TradePartner { get; set; }
        public List<TileRessources> TileRessources { get; set; }
        public int FoodRations { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public double Gold { get; set; }
        public string Name { get; set; }
        public Guid VillageID { get; set; }

        public Village(int x, int y, string name)
        {
            TradePartner = new List<Village>();
            TileRessources = new List<TileRessources>();
            this.VillageID = Guid.NewGuid();
            // Merke, niemals irgendwelche delegaten/events im konstruktor aufrufen
            Popul = 0;
            PosX = x;
            PosY = y;
            Gold = 0;
            this.Name = name;
            VillageProgressHandler.RegisterVillage(this);
        }

        #region ScanLogic 
        public void GetTradePartners()
        {
            var x = OnCallForScan(new VillageScanEventArgs(this, null)); 
            TradePartner.AddRange(x.ResultVillage);
            //Console.WriteLine("Das Dorf hat " + TradePartner.Count + " Handelspartner");
            Console.WriteLine($"Das Dorf {this.Name} hat {TradePartner.Count} Handelspartner in der Umgebung");
        }

        public void GetProxRessources()
        {
            var x = OnCallForResource(new RessourceScanEventArgs(this, null));
            TileRessources.AddRange(x.Ressources);
            //Console.WriteLine("Das Dorf hat " + TileRessources.Count + " Ressourcen");
            Console.WriteLine($"Das Dorf hat {TileRessources.Count} Ressourcen in der Umgebung");
        }
        #endregion

        #region Events
        public VillageScanEventArgs OnCallForScan(VillageScanEventArgs e)
        {

            if (CallForNeighborScan != null)
            {
                CallForNeighborScan.Invoke(e);
            }
            return e;
        }
        public RessourceScanEventArgs OnCallForResource(RessourceScanEventArgs e)
        {
            if (CallForResourceScan != null)
            {
                CallForResourceScan.Invoke(e);
            }
            return e;
        }
        #endregion

        #region DebugMist
        protected void IncreaseGold(int par0)
        {
            Gold += par0;
        }
        protected void IncreasePopul()
        {

        }
        #endregion
    }

}
