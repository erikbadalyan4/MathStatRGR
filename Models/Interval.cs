using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathStatRGR.Models
{
    class Interval
    {
        public double x1 { get; set; }
        public double x2 { get; set; }
        public double ni { get; set; }
        public double wi { get; set; }
        public double intervalMedium { get; }
        public double pi { get; set; }

        public static double n { get; set; } = 0;

        public Interval(double x1, double x2, double ni) 
        {
            this.x1 = x1;
            this.x2 = x2;
            this.ni = ni;
            intervalMedium = (x1 + x2) / 2;

            n += ni;
        }
        
        
    }
}
