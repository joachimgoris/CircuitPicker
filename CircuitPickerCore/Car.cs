using Newtonsoft.Json;

namespace CircuitPickerCore
{
    internal class Car
    {
        [JsonProperty("carId")]
        public int Id { get; set; }
        [JsonProperty("brand")]
        public string Brand { get; set; }
        [JsonProperty("model")]
        public string Model { get; set; }
        [JsonProperty("year")]
        public int Year { get; set; }
        [JsonProperty("isDLC")]
        public bool IsDlc { get; set; }
        [JsonProperty("DlcPack")]
        public Dlc DlcPack { get; set; }
    }
}