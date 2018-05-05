using Newtonsoft.Json;

namespace CircuitPicker
{
    internal class Circuit
    {
        [JsonProperty("circuitId")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("layout")]
        public string Layout { get; set; }
    }
}