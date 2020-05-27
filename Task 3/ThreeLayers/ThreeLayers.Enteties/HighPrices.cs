using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeLayers.Entities
{
    public class HighPrices
    {
        string _name;
        string _rich;
        public HighPrices() { }
        public HighPrices(string name, string rich)
        {
            _name = name;
            _rich = rich;
        }
    }
}
