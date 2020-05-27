using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeLayers.Entities
{
    public class Dish
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Weight { get; set; }
        public decimal Callories { get; set; }

        public int Country { get; set; }
        public int IsVegan { get; set; }

        public decimal Price { get; set; }
        public int EXP { get; set; }

        public int idlist { get; set; }

        public Dish() { }

        public Dish(int id, string n, decimal w, decimal c,int coun, int isv, decimal pr, int EXP,int i)
        {
            Id = id;
            Name = n;
            Weight = w;
            Callories = c;
            Country = coun;
            IsVegan = isv;
            Price = pr;
            this.EXP = EXP;
            idlist = i;
        }
    }
}
