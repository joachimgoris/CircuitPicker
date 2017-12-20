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
            using (StreamReader r = new StreamReader(@"C:\Source\Repos\CircuitPicker\Circuits.json"))
            {
                string json = r.ReadToEnd();
                circuits = JsonConvert.DeserializeObject<List<Circuit>>(json);
            }
            Random rdm = new Random();
            string input;
            do
            {
                int nr = rdm.Next(circuits.Count - 1);
                StringBuilder str =
                    new StringBuilder("Name: " + circuits[nr].Name + "\nLocation: " + circuits[nr].Location +
                                      "\nLayout: ");
                var layouts = circuits[nr].Layout.Split('|');
                nr = rdm.Next(layouts.Length - 1);
                str.Append(layouts[nr]);
                Console.WriteLine(str.ToString());
                input = Console.ReadLine();
                Console.Clear();
            } while (input !="N");
        }
    }

    class Payload
    {
        [JsonProperty("circuits")]
        public List<Circuit> Circuits { get; set; }
    }

    internal class Circuit
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
