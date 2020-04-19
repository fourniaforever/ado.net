using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Circle
    {
        public double r;
        public Point center;
        public Circle(Point center,double r)
        {
            this.center = center;
            this.r = r;
        }
        public virtual string Show()
        {
            return "Координаты:" + center.Show() + "\n" +"Радиус:"+ r + "\n";
        }
        public virtual double S
        {
            get
            {
                return Math.PI * (r * r);
            }
            set
            {
                S = Math.PI * (r * r);
            }
        }

        public virtual double C_summ
        {
            get
            {
                return 2 * Math.PI * r;
            }
            set
            {
                C_summ = 2 * Math.PI * r;
            }
        }
    }
}
