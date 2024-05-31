using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileDance.Utilities
{
    public static class NameGenerator
    {
        static List<string> name0 = new List<string>(){
                "Unter",
                "Ober",
                "Neu",
                "Burg",
                "Bad",
                "Boden",
                "Berg",
                "West",
                "Ahrens"
                
            
            };
        static List<string> name1 = new List<string>(){
                "hausen",
                "dorf",
                "stadt",
                "bergkreis",
                "baden",
                "burg",
                "see",
                "straße",
                "weiler"
                
            };

        
        public static string GetRandomVillageName()
        {
            Random random = new Random();
            string res;
            int x, y;
            x = random.Next(0,name0.Count);
            y = random.Next(0,name1.Count);
            res = name0[x] + name1[y];
            return res;
        }
    }
}
