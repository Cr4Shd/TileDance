using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileDance.Map
{
    internal interface IMapTile
    {
        public void GenerateTileEnviroment();
        public void GenerateTileRessources();
        public void GenerateVillageOnTile();
    }
}
