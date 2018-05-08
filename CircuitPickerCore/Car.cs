using Newtonsoft.Json;

namespace CircuitPickerCore
{
    internal abstract class Car
    {
        [JsonProperty("carId")]
        public int Id { get; set; }
        [JsonProperty("brand")]
        public string Brand { get; set; }
        [JsonProperty("model")]
        public string Model { get; set; }
        [JsonProperty("isDLC")]
        public bool IsDlc { get; set; }
        [JsonProperty("dlcPack")]
        public DlcPc DlcPack { get; set; }
    }

    internal class CarPc : Car
    {
        [JsonProperty("year")]
        public int Year { get; set; }
    }

    internal class CarAc : Car { }
}