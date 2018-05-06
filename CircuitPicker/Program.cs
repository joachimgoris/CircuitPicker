using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace CircuitPicker
{
    internal class Program
    {
        private static List<Circuit> _circuits;
        private static List<Car> _cars;

        private static void Main()
        {
            
            string defaultFilePath = Directory.GetCurrentDirectory();
            int amountTracks=1, amountCars=1;
            bool readSucces=false, amountSucces=false;
            Console.WriteLine("Choose your game. 1 for PC2, 2 for AC");
            string input = Console.ReadLine();
            Game gamePick = input != null && input.Equals("1") ? Game.ProjectCars : Game.AssettoCorsa;
            Console.WriteLine("Give the absolute file path for your json file.(Press A for default)");
            do
            {
                input = Console.ReadLine();
                if (input != null && input.ToLower()!="a")
                {
                    try
                    {
                        ReadFiles(input,gamePick);
                        readSucces = true;
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("File not found.");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Something went wrong.");
                    }

                }
                else
                {
                    try
                    {
                        ReadFiles(defaultFilePath, gamePick);
                        readSucces = true;
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("File not found.");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Something went wrong.");
                    }

                }
            } while (!readSucces);

            do
            {
                Console.WriteLine("How much tracks do you want to generate?");
                try
                {
                    amountTracks = Convert.ToInt32(Console.ReadLine());
                    amountSucces = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Unreadable format.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong.");
                }

                Console.WriteLine("How much cars do you want to generate?");
                try
                {
                    amountCars = Convert.ToInt32(Console.ReadLine());
                    amountSucces = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Unreadable format.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong.");
                }
            } while (!amountSucces);
            Console.Clear();
            Generate(amountTracks, amountCars);
        }

        internal static void ReadFiles(string filePath, Game game)
        {
            string postfixCircuits="\\Circuits";
            string postfixCars = "\\Cars";
            postfixCircuits = game.Equals(Game.AssettoCorsa)
                ? postfixCircuits + "AC.json"
                : postfixCircuits + "PC2.json";
            postfixCars = game.Equals(Game.AssettoCorsa)
                ? postfixCars +"AC.json"
                : postfixCars + "PC2.json";

            using (StreamReader r = new StreamReader(filePath+postfixCircuits))
            {
                string json = r.ReadToEnd();
                _circuits = JsonConvert.DeserializeObject<List<Circuit>>(json);
            }
            using (StreamReader r = new StreamReader(filePath+postfixCars))
            {
                string json = r.ReadToEnd();
                _cars = JsonConvert.DeserializeObject<List<Car>>(json);
            }
        }

        internal static void Generate(int amountTracks, int amountCars)
        {
            Random rdm = new Random();
            string input;

            do
            {
                string strCar="";
                StringBuilder strCircuit= new StringBuilder();
                for (int i = 0; i < amountCars; i++)
                {
                    int rdmCar = rdm.Next(_cars.Count - 1);
                    strCar += $"Car {i+1}: {_cars[rdmCar].Brand} {_cars[rdmCar].Type} {_cars[rdmCar].Year}";
                    if (_cars[rdmCar].IsDlc)
                    {
                        strCar += _cars[rdmCar].DlcPack;
                    }

                    strCar += "\n";
                }

                for (int i = 0; i < amountTracks; i++)
                {
                    int rdmCircuit = rdm.Next(_circuits.Count - 1);
                    strCircuit.Append($"Circuit {i+1}:\nName: {_circuits[rdmCircuit].Name}\nLocation: {_circuits[rdmCircuit].Location}\nLayout: ");
                    string[] layouts = _circuits[rdmCircuit].Layout.Split('|');
                    rdmCircuit = rdm.Next(layouts.Length - 1);
                    strCircuit.Append(layouts[rdmCircuit]+"\n\n");
                }
                Console.WriteLine(strCar);
                Console.WriteLine(strCircuit.ToString());
                input = Console.ReadLine();
                Console.Clear();
            } while (input != null && input.ToLower() != "n");
        }

        
    }
}

