using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace CircuitPickerCore
{
    public class Functions
    {
        private static List<Car> _cars = new List<Car>();
        private  static List<Circuit> _circuits = new List<Circuit>();

        public static void ReadFiles(string filePath, Game game)
        {
            string postfixCircuits = "\\Circuits";
            string postfixCars = "\\Cars";
            postfixCircuits = game.Equals(Game.AssettoCorsa)
                ? postfixCircuits + "AC.json"
                : postfixCircuits + "PC2.json";
            postfixCars = game.Equals(Game.AssettoCorsa)
                ? postfixCars + "AC.json"
                : postfixCars + "PC2.json";

            using (StreamReader r = new StreamReader(filePath + postfixCircuits))
            {
                string json = r.ReadToEnd();
                _circuits = JsonConvert.DeserializeObject<List<Circuit>>(json);
            }
            using (StreamReader r = new StreamReader(filePath + postfixCars))
            {
                string json = r.ReadToEnd();
                _cars = JsonConvert.DeserializeObject<List<Car>>(json);
            }
        }

        public static void Generate(int amountTracks, int amountCars)
        {
            Random rdm = new Random();
            string input;

            do
            {
                string strCar = "";
                StringBuilder strCircuit = new StringBuilder();
                for (int i = 0; i < amountCars; i++)
                {
                    int rdmCar = rdm.Next(_cars.Count - 1);
                    strCar += $"Car {i + 1}: {_cars[rdmCar].Brand} {_cars[rdmCar].Type} {_cars[rdmCar].Year}";
                    if (_cars[rdmCar].IsDlc)
                    {
                        strCar += _cars[rdmCar].DlcPack;
                    }

                    strCar += "\n";
                }

                for (int i = 0; i < amountTracks; i++)
                {
                    int rdmCircuit = rdm.Next(_circuits.Count - 1);
                    strCircuit.Append($"Circuit {i + 1}:\nName: {_circuits[rdmCircuit].Name}\nLocation: {_circuits[rdmCircuit].Location}\nLayout: ");
                    string[] layouts = _circuits[rdmCircuit].Layout.Split('|');
                    rdmCircuit = rdm.Next(layouts.Length - 1);
                    strCircuit.Append(layouts[rdmCircuit] + "\n\n");
                }
                Console.WriteLine(strCar);
                Console.WriteLine(strCircuit.ToString());
                input = Console.ReadLine();
                Console.Clear();
            } while (input != null && input.ToLower() != "n");
        }

        public static void GenerateFilter(DlcAc dlcAc, int amountTracks, int amountCars)
        {
            Random rdm = new Random();
            string input;
            List<Car> _modifiedCars = new List<Car>();

            //Filter lists
            foreach (Car car in _cars)
            {
                if (!car.IsDlc) continue;
                if (car.DlcPack.Contains(dlcAc.ToString()))
                {
                    _modifiedCars.Add(car);
                }
            }

            
            
                string strCar = "";
                StringBuilder strCircuit = new StringBuilder();
                for (int i = 0; i < amountCars; i++)
                {
                    
                }
            
        }

        private static void GenerateFilter(DlcPc dlcPc)
        {

        }
    }
}
