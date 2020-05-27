using System;
using System.Text;
using System.Collections.Generic;
namespace ThreeLayers.Entities
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Weight { get; set; }
        public decimal Callories { get; set; }

        public int IsVegan { get; set; }

        public decimal Price { get; set; }
        public int EXP { get; set; }

        public Products() { }

        public Products(int id,string n, decimal w, decimal c,int isv, decimal pr,int EXP) 
        {
            Id = id;
            Name = n;
            Weight = w;
            Callories = c;
            IsVegan = isv;
            Price = pr;
            this.EXP = EXP;
        }
    }
}