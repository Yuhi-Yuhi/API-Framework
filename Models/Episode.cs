using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Framework.Models
{
    public class Episode
    {
        [JsonPropertyName("id")]
        public required int Id { get; set; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("number")]
        public required int Number { get; set; }

        [JsonPropertyName("productionCode")]
        public required string ProductionCode { get; set; }

        [JsonPropertyName("airDate")]
        public required string? AirDate { get; set; }

        [JsonPropertyName("duration")]
        public required int? Duration { get; set; }

        [JsonPropertyName("createdAt")]
        public required DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("broadcastCode")]
        public required string BroadcastCode { get; set; }

        public static Episode GetDefaultEpisode()
        {
            return new Episode
            {
                Id = 1,
                Name = "Space Pilot 3000",
                Number = 1,
                ProductionCode = "1ACV01",
                AirDate = "1999-03-28",
                Duration = 1800,
                CreatedAt = DateTime.Parse("2023-12-21T21:04:02.717418Z"),
                BroadcastCode = "S01E01"
            };
        }

        public static Episode GetEpisode1()
        {
            return new Episode
            {
                Id = 1,
                Name = "Space Pilot 3000",
                Number = 1,
                ProductionCode = "1ACV01",
                AirDate = "1999-03-28",
                Duration = 1800,
                CreatedAt = DateTime.Parse("2023-12-21T21:04:02.717418Z"),
                BroadcastCode = "S01E01"
            };
        }

        public static Episode GetEpisode5()
        {
            return new Episode
            {
                Id = 5,
                Name = "Fear of a Bot Planet",
                Number = 5,
                ProductionCode = "1ACV05",
                AirDate = "1999-04-20",
                Duration = 1800,
                CreatedAt = DateTime.Parse("2023-12-21T21:04:02.717418Z"),
                BroadcastCode = "S01E05"
            };
        }

        public static Episode GetEpisode27() 
        {
            return new Episode
            {
                Id = 27,
                Name = "Mother's Day",
                Number = 19,
                ProductionCode = "2ACV14",
                AirDate = "2000-05-14",
                Duration = 1800,
                CreatedAt = DateTime.Parse("2023-12-21T21:04:02.717418Z"),
                BroadcastCode = "S02E19"
            };
        }
    }
    
}
