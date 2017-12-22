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
            List<Car> cars;
            using (StreamReader r = new StreamReader(@"C:\Source\Repos\CircuitPicker\Circuits.json"))
            {
                string json = r.ReadToEnd();
                circuits = JsonConvert.DeserializeObject<List<Circuit>>(json);
            }
            using (StreamReader r = new StreamReader(@"C:\Source\Repos\CircuitPicker\Cars.json"))
            {
                string json = r.ReadToEnd();
                cars = JsonConvert.DeserializeObject<List<Car>>(json);
            }
            Random rdm = new Random();
            string input;
            do
            {
                int rdmCircuit = rdm.Next(circuits.Count - 1);
                int rdmCar = rdm.Next(cars.Count - 1);
                string strCar;
                if (cars[rdmCar].IsDlc == true)
                {
                    strCar = ("Car :" + cars[rdmCar].Brand + " " + cars[rdmCar].Type + " " + cars[rdmCar].Year +
                                     " DLC: " + cars[rdmCar].DlcPack);
                }
                else
                {
                    strCar = ("Car :" + cars[rdmCar].Brand + " " + cars[rdmCar].Type + " " + cars[rdmCar].Year);
                }

                StringBuilder strCircuit =
                    new StringBuilder("Name: " + circuits[rdmCircuit].Name + "\nLocation: " + circuits[rdmCircuit].Location +
                                      "\nLayout: ");
                var layouts = circuits[rdmCircuit].Layout.Split('|');
                rdmCircuit = rdm.Next(layouts.Length - 1);
                strCircuit.Append(layouts[rdmCircuit]);
                Console.WriteLine(strCar);
                Console.WriteLine(strCircuit.ToString());
                input = Console.ReadLine();
                Console.Clear();
            } while (input.ToLower() != "n");
        }
    }

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
