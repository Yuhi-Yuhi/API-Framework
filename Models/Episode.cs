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
        public required int nubmer { get; set; }
        public required string productionCode { get; set; }
        public required string? airDate { get; set; }
        public required int? duration { get; set; }
        public required DateTime createdAt { get; set; } 
        public required string broadcastCode { get; set; }

        public static Episode GetDefaultEpisode()
        {
            return new Episode
            {
                id = 1,
                name = "Space Pilot 3000",
                nubmer = 1,
                productionCode = "1ACV01",
                airDate = "1999-03-28",
                duration = 1800,
                createdAt = DateTime.Parse("2023-12-21T21:04:02.717418Z"),
                broadcastCode = "S01E01"
            };
        }

        public static Episode GetEpisode1()
        {
            return new Episode
            {
                id = 1,
                name = "Space Pilot 3000",
                nubmer = 1,
                productionCode = "1ACV01",
                airDate = "1999-03-28",
                duration = 1800,
                createdAt = DateTime.Parse("2023-12-21T21:04:02.717418Z"),
                broadcastCode = "S01E01"
            };
        }

        public static Episode GetEpisode5()
        {
            return new Episode
            {
                id = 5,
                name = "Fear of a Bot Planet",
                nubmer = 5,
                productionCode = "1ACV05",
                airDate = "1999-04-20",
                duration = 1800,
                createdAt = DateTime.Parse("2023-12-21T21:04:02.717418Z"),
                broadcastCode = "S01E05"
            };
        }

        public static Episode GetEpisode27() 
        {
            return new Episode
            {
                id = 27,
                name = "Mother's Day",
                nubmer = 19,
                productionCode = "2ACV14",
                airDate = "2000-05-14",
                duration = 1800,
                createdAt = DateTime.Parse("2023-12-21T21:04:02.717418Z"),
                broadcastCode = "S02E19"
            };
        }
    }
    
}
