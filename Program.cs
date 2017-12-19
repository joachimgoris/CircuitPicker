using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace CircuitPicker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            List<Circuit> circuits = new List<Circuit>();

            
            XElement xDocument = XElement.Load("Circuits.xml");
            IEnumerable<XElement> c = xDocument.Elements();
            foreach (var circuit in c)
            {
                Console.WriteLine (c);
            }
            


            Console.ReadLine();
        }
    }

    class Circuit
    {
        private string Name;
        private string Location;
        private List<string> Layouts;
        
        public string getName(){
            return Name;
        }

        public string getLocation(){
            return Location;
        }

        public List<string> getLayouts(){
            return Layouts;
        }

        public void setName(string name){
            Name = name;
        }

        public void setLocation(string location){
            Location = location;
        }

        public void addLayout(string layout){
            Layouts.Add(layout);
        }
    }
}
