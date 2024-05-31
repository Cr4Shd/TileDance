using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileDance.Map;

namespace TileDance.Village.VillageEventArgs
{
    class RessourceScanEventArgs
    {
        public object Sender { get; set; }
        public IEnumerable<TileRessources>? Ressources { get; set; }

        public RessourceScanEventArgs(object sender, IEnumerable<TileRessources> tileRessources)
        {
            this.Sender = sender;
            this.Ressources = tileRessources;
        }
    }
}
