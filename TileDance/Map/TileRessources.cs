using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileDance.Map
{
    class TileRessources
    {
        /// <summary>
        /// Iron 0, Gold 1, Wheat 2, WildLife 3
        /// </summary>
        public enum KindOf
        {
            Iron = 0,
            Gold = 1,
            Wheat = 2,
            Wildlife = 3,
            Wood = 4
        }
        public KindOf KindOfRes { get; set; }

        public TileRessources(int par0)
        {
            KindOfRes = (KindOf)par0;
        }
    }
}
