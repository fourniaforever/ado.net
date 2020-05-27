using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeLayers.Entities
{
    public class NotVeganRecips
    {

        string _name { get; set; }
        string _vegan { get; set; }

        public NotVeganRecips() { }
        public NotVeganRecips(string name, string vegan)
        {
            _name = name;
            _vegan = vegan;
        }
    }
}
