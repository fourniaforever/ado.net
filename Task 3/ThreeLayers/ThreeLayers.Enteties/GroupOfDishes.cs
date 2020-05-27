using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeLayers.Entities
{
    public class GroupOfDishes
    {
        public int iddish { get; set; }
        public int id { get; set; }
        public string Name { get; set; }

        public GroupOfDishes() { }
        public GroupOfDishes(int idd,int i,string n)
        {
            iddish = idd;
            id = i;
            Name = n;
        }
    }
}
