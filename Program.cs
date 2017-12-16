using System;
using System.Collections.Generic;

namespace CircuitPicker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");

            
            
            foreach (var item in Data.Circuits)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
