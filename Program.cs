using System;
using System.Collections.Generic;

namespace CircuitPicker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");

            List<string> circuits = new List<string>(){"Zolder","Spa" };
            
            foreach (var item in circuits)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
