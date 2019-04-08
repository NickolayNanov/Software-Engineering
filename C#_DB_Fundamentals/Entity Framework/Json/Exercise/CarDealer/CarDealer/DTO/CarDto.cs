using CarDealer.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarDealer.DTO
{
    public class CarDto
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty("make")]
        public string Make { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("travelledDistance")]
        public long TravelledDistance { get; set; }

        [JsonIgnore]
        public ICollection<Sale> Sales { get; set; }

        [JsonProperty("partsId")]
        public ICollection<int> PartsId { get; set; } = new List<int>();
    }
}
