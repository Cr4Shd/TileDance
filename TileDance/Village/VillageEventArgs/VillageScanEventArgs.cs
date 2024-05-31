using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileDance.Map;

namespace TileDance.Village.VillageEventArgs
{
    class VillageScanEventArgs
    {
        public object Sender { get; set; }
        public IEnumerable<Village>? ResultVillage { get; set; }
        

        public VillageScanEventArgs(object sender, IEnumerable<Village>? vil)
        {
            
            Sender = sender;
            ResultVillage = vil;
        }
        
    }
}
