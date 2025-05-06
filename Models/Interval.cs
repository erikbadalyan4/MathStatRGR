using System;

namespace MathStatRGR.Models
{
    public class Interval
    {
        public double x1 { get; set; }
        public double x2 { get; set; }
        public double ni { get; set; }
        public double wi { get; set; }
        public double intervalMedium { get; private set; }
        public double pi { get; set; }
        public double npi => pi * n;

        public static double n { get; set; } = 0;

        public Interval(double x1, double x2, double ni)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.ni = ni;

            SetIntervalMedium();

            n += ni;
        }

        public void SetIntervalMedium() => intervalMedium = (x1 + x2) / 2;
        public void SetWi()
        {
            wi = ni / n;
        }

        public double NiMinusNpiInSquare => Math.Pow(ni - npi, 2);
    }
}