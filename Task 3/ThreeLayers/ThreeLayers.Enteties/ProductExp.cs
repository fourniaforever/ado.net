using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeLayers.Entities
{
    public class ProductExp
    {
        string _name { get; set; }
        string _expd { get; set; }
        DateTime _date { get; set; }
        public ProductExp() { }
        public ProductExp(string name, string expd, DateTime date)
        {
            _name = name;
            _expd = expd;
            _date = date;
        }
    }
}
