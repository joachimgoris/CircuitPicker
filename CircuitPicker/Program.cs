using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CircuitPicker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Circuit> circuits;
            using (StreamReader r = new StreamReader(@"C:\Users\goris\Source\Repos\CircuitPicker\Circuits.json"))
            {
                string json = r.ReadToEnd();
                circuits = JsonConvert.DeserializeObject<List<Circuit>>(json);
            }
            foreach (var v in circuits)
            {
                Console.WriteLine(v.Name);
            }
            Console.ReadLine();
        }
    }

    class Payload
    {
        [JsonProperty("circuits")]
        public List<Circuit> Circuits { get; set; }
    }
    class Circuit
    {
        [JsonProperty("circuitId")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public  string Name { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("layout")]
        public string Layout { get; set; }       
    }
}
