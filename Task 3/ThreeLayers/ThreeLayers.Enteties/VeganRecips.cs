using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeLayers.Entities
{
    public class VeganRecips
    {
        string _name { get; set; }
        string _vegan { get; set; }

        public VeganRecips() { }
        public VeganRecips(string name, string vegan)
        {
            _name = name;
            _vegan = vegan;
        }
    }
}
