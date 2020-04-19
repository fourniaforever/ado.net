using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Task1
{
    public class Triangle
    {
        public Point a;
        public Point b;
        public Point c;

        public Triangle() { }

        public Triangle(Point a, Point b, Point c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }



        public double Path(Point p1, Point p2)
        {
            return Math.Sqrt((p2.x - p1.x) * (p2.x - p1.x) + (p2.y - p1.y) * (p2.y - p1.y));
        }

        public string Show()
        {
            return "Координаты точки a = ("+ a.x +","+ a.y+ ")\nКоординаты точки b = ("+ b.x + "," + b.y +") \nКоординаты точки c = ("+c.x + "," + c.y+")\n";
        }
         
        public double S
        {
            get
            {
                return Math.Sqrt(P / 2 * (P / 2 - Path(a, b)) * (P / 2 - Path(b, c)) * (P / 2 - Path(c, a))); 
            }
            set
            {
                S = Math.Sqrt(P / 2 * (P / 2 - Path(a, b)) * (P / 2 - Path(b, c)) * (P / 2 - Path(c, a)));
            }
        }

        public double P
        {
            get 
            { 
                return Path(a, b) + Path(b, c) + Path(c, a);
            }
            set
            {
                P = Path(a, b) + Path(b, c) + Path(c, a);
            }
        }
    }
}
