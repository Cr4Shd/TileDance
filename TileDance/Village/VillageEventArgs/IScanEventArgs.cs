using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileDance.Village.VillageEventArgs
{
    interface IScanEventArgs <T>
    {
        public object Sender { get; set; }
        public IEnumerable<T> ReturnList { get; set; }
    }
}
