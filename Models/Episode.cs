using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Models
{
    public class Episode
    {
        public required int id { get; set; }
        public required string name { get; set; }
        public required string productionCode { get; set; }
        public required int duration { get; set; }

        public static Episode GetDefaultEpisode() 
        {
            return new Episode 
            { 
                id = 1, 
                name = "Space Pilot 3000", 
                productionCode = "1ACV01",
                duration = 1800
            };
        }
    }
    
}
