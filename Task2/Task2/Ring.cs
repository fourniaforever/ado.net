using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Ring:Circle
    {
        public double inner_r;
        public Ring(Point center,double r,double inner_r):base(center,r)
        {
            this.inner_r = inner_r;
        }

        public override string Show()
        {
            return base.Show() + "Внутренний радиус:" + inner_r + "\n";
        }
        public override double S 
        {
            get
            {
                return Math.PI * (r * r - inner_r * inner_r);
            }
            set
            {
                S = Math.PI * (r * r - inner_r * inner_r);
            }
        }

        public override double C_summ
        {
            get
            {
                return 2 * Math.PI * r + 2 * Math.PI * inner_r;
            }
            set 
            {
                C_summ = 2 * Math.PI * r + 2 * Math.PI * inner_r;
            }
        }
    }
}
