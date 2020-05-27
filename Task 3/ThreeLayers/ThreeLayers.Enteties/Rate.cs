using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeLayers.Entities
{
    public class Rate
    {
        public int idDish { get; set; }
        public DateTime date { get; set; }
        public int Rating { get; set; }

        public Rate() { }
        public Rate(int id,DateTime d,int r) 
        {
            idDish = id;
            date = d;
            Rating = r;
        }
    }
}
