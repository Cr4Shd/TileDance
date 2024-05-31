using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileDance.Map
{
    class MapTile : IMapTile
    {
        public delegate void TileCallForScan(MapTile tile);
        public static event TileCallForScan CallForScan;

        public Guid TileID { get; set; }
        public int TileXCoord { get; set; }
        public int TileYCoord { get; set; }
        public Village.Village? VillageOnTile { get; set; }
        public TileRessources _TileRessources { get; set; }

        #region EnumEnviroment
        public enum Enviroment
        {
            Water = 0,
            Desert = 1,
            Mountain = 2,
            Ocean = 3,
            Field = 4,
            Woodlands = 5,
            Plains = 6
        }

        public Enviroment TileEnv { get; set; }
        #endregion

        public MapTile(int x, int y)
        {
            TileXCoord = x;
            TileYCoord = y;
            TileID = Guid.NewGuid();
            this.GenerateTileEnviroment();
            this.GenerateTileRessources();

            if (this.TileEnv != Enviroment.Ocean && this.TileEnv != Enviroment.Water )
            {
                GenerateVillageOnTile();
            }
            
        }

        // Idee : Wie wäre es wenn man statt die Verteilung innerhalb der MapTile Klasse als methode hat, die Verteilung mit einer eigenen Klasse verwirklicht
        // So hat man Zugriff darauf was als letztes gesetzt wurde und kann Einfluss darauf nehmen was als nächstes kommt
        public void GenerateTileEnviroment()
        {
            var r = new Random();
            int x = r.Next(0, 6);
            switch (x)
            {
                case 0:
                    this.TileEnv = Enviroment.Water; break;
                case 1:
                    this.TileEnv = Enviroment.Desert; break;
                case 2:
                    this.TileEnv = Enviroment.Mountain; break;
                case 3:
                    this.TileEnv = Enviroment.Ocean; break;
                case 4:
                    this.TileEnv = Enviroment.Field; break;
                case 5:
                    this.TileEnv = Enviroment.Woodlands; break;
                case 6:
                    this.TileEnv = Enviroment.Plains; break;
                default:
                    break;
            }
        }
        public void GenerateTileRessources()
        {
            switch(this.TileEnv)
            {
                case Enviroment.Water: break;
                case Enviroment.Ocean: break;
                case Enviroment.Desert: break;


                case Enviroment.Mountain:
                    this._TileRessources = new TileRessources(0);
                    break;
                case Enviroment.Field:
                    this._TileRessources = new TileRessources(2);
                    break;
                case Enviroment.Woodlands:
                    this._TileRessources = new TileRessources(4);
                    break;
                case Enviroment.Plains:
                    this._TileRessources = new TileRessources(3);
                    break;
            }
        }


        //Hardcoded for test
        public void GenerateVillageOnTile()
        {
            
            Random r = new Random();
            int x = (r.Next(0,9));
            if (x > 2)
            {
                this.VillageOnTile = new Village.Village(this.TileXCoord, this.TileYCoord, Utilities.NameGenerator.GetRandomVillageName());
                Console.WriteLine($"Dorf {this.VillageOnTile.Name} auf Tile X {this.TileXCoord} Y {this.TileYCoord} generiert");
            }
        }
        public void OnTileCallsForScan(MapTile tile)
        {
            if (CallForScan != null)
            {
                CallForScan.Invoke(this);
            }
        }
        public void AddVillage(Village.Village vil)
        {
            if (vil == null)
            {
                VillageOnTile = vil;
            }
        }
    }
}
