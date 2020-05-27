using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeLayers.Entities
{
    public class Process
    {
        public int id { get; set; }
        public string Name { get; set; }

        public Process() { }
        public Process(int i,string n)
        {
            id = i;
            Name = n;
        }
    }
}
