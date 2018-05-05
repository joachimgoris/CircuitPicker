using Newtonsoft.Json;

namespace CircuitPicker
{
    internal class Car
    {
        [JsonProperty("carId")]
        public int Id { get; set; }
        [JsonProperty("brand")]
        public string Brand { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("year")]
        public int Year { get; set; }
        [JsonProperty("isDLC")]
        public bool IsDlc { get; set; }
        [JsonProperty("dlcPack")]
        public string DlcPack { get; set; }
    }
}