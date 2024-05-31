using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileDance.Enties
{
    class Villager : IVillager
    {
        public int Age { get; set; }
        public enum Sex
        {
            Male = 0,
            Female = 1
        }
        public Sex _Sex { get; set; }
        public Villager()
        {
            switch (GlobalVars.VillagerSexState)
            {
                case 0:
                    this._Sex = Sex.Male;
                    GlobalVars.VillagerSexState = 1;
                    break;
                case 1:
                    this._Sex = Sex.Female;
                    GlobalVars.VillagerSexState = 0;
                    break;
                default:
                    break;
            }
        }
        public void IncreaseAge()
        {
            this.Age += 1;
        }
    }
}
