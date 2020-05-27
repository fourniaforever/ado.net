using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeLayers.Entities
{
    public class Countries
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Countries(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public Countries() { }
    }
}