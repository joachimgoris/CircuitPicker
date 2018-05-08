using System;
using System.IO;
using CircuitPickerCore;

namespace CircuitPicker
{
    internal class Program
    {
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
                        Functions.ReadFiles(input,gamePick);
                        readSucces = true;
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("File not found.");
                    }
                    //catch (Exception)
                    //{
                      //  Console.WriteLine("Something went wrong.");
                    //}

                }
                else
                {
                    try
                    {
                        Functions.ReadFiles(defaultFilePath, gamePick);
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

            Functions.GenerateFilter(DlcAc.RedPack, 1, 2);
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
            Functions.Generate(amountTracks, amountCars);
        }
    }
}

