using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Point
    {
        public double x;
        public double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public string Show()
        {
            return "(" + x + ", " + y + ")";
        }
    }
}
