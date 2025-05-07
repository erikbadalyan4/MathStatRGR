using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace MathStatRGR.StatisticsCalculator
{
    class HypothesesCalculator
    {
        private readonly List<Models.Interval> intervals;
        private readonly double x_avg;
        private readonly double mean_square;
        private readonly double a;
        private readonly int r;

        public HypothesesCalculator(List<Models.Interval> intervals, double a, int r = 2)
        {
            this.intervals = intervals;
            this.a = a;
            this.r = r;

            x_avg = intervals.Sum(item => item.intervalMedium * item.ni) / Models.Interval.n;
            double disp = intervals.Sum(item => Math.Pow(item.intervalMedium - x_avg, 2) * item.ni) / Models.Interval.n;
            double correctedDisp = Models.Interval.n / (Models.Interval.n - 1) * disp;
            mean_square = Math.Sqrt(correctedDisp);
        }

        private double Laplace(double t)
        {
            return Normal.CDF(0, 1, t) - Normal.CDF(0, 1, 0);
        }

        public string Pirson()
        {
            foreach (var item in intervals)
            {
                double laplace2 = Laplace((item.x2 - x_avg) / mean_square);
                double laplace1 = Laplace((item.x1 - x_avg) / mean_square);
                item.pi = laplace2 - laplace1;
            }

            double chi2 = intervals.Sum(item => item.NiMinusNpiInSquare / item.npi);
            int k = intervals.Count - r - 1;
            double chi2_kr = ChiSquared.InvCDF(k, 1 - a);

            string result = $"χ² = {chi2:F4}\n";
            result += $"χ² кр. = {chi2_kr:F4}\n";

            if (chi2 < chi2_kr)
            {
                result += $"Так как χ² < χ² кр., нулевая гипотеза H0: X~N({x_avg:F4}, {mean_square:F4}) согласуется с опытными данными.";
            }
            else
            {
                result += $"Так как χ² >= χ² кр., нулевая гипотеза H0: X~N({x_avg:F4}, {mean_square:F4}) не согласуется с опытными данными.";
            }

            return result;
        }

        public string Kolmogorov()
        {
            List<double> f = intervals.Select(item => 0.5 + Laplace((item.x1 - x_avg) / mean_square)).ToList();
            f.Add(0.5 + Laplace((intervals.Last().x2 - x_avg) / mean_square));

            List<double> wi_acc = new List<double> { 0 };
            double ni_acc = 0;
            foreach (var item in intervals)
            {
                ni_acc += item.ni;
                wi_acc.Add(ni_acc / Models.Interval.n);
            }

            double d = f.Zip(wi_acc, (f_val, wi_val) => Math.Abs(wi_val - f_val)).Max();

            double l = d * Math.Sqrt(Models.Interval.n);
            double la = Math.Sqrt(-0.5 * Math.Log(a / 2)); 

            string result = $"l = {l:F4}\n";
            result += $"l({a}) = {la:F4}\n";

            if (l <= la)
            {
                result += $"Так как l <= l({a}), нулевая гипотеза H0: X~N({x_avg:F4}, {mean_square:F4}) согласуется с опытными данными.";
            }
            else
            {
                result += $"Так как l > l({a}), нулевая гипотеза H0: X~N({x_avg:F4}, {mean_square:F4}) не согласуется с опытными данными.";
            }

            return result;
        }

        public void SetupChart(Chart chart)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();

            var chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            var histogramSeries = new Series("Гистограмма")
            {
                ChartType = SeriesChartType.Column,
                Color = System.Drawing.Color.Blue,
                BorderColor = System.Drawing.Color.Black,
                ["PointWidth"] = "1" 
            };

            List<double> intervals_centers = new List<double>();
            List<double> intervals_wi = new List<double>();
            double interval_min_x = double.PositiveInfinity;
            double interval_max_x = double.NegativeInfinity;

            foreach (var item in intervals)
            {
                item.SetWi();
                intervals_wi.Add(item.wi);
                intervals_centers.Add(item.intervalMedium);

                if (interval_min_x > item.x1) interval_min_x = item.x1;
                if (interval_max_x < item.x2) interval_max_x = item.x2;
            }

            var midDiff = Math.Abs(intervals_centers[1] - intervals_centers[0]); // 25

            for (int i = 0; i < intervals_centers.Count; i++)
            {
                histogramSeries.Points.AddXY(intervals_centers[i], intervals_wi[i]);
            }

            chart.Series.Add(histogramSeries);

            var pdfSeries = new Series("Нормальная кривая")
            {
                ChartType = SeriesChartType.Line,
                Color = System.Drawing.Color.Red,
                BorderWidth = 2
            };

            double disp = intervals.Sum(item => Math.Pow(item.intervalMedium - x_avg, 2) * item.ni) / Models.Interval.n;
            double scale_factor = intervals_wi.Max() / Normal.PDF(x_avg, Math.Sqrt(disp), intervals_centers.Average());

            int numPoints = 100;
            double step = (interval_max_x - interval_min_x) / (numPoints - 1);
            for (int i = 0; i < numPoints; i++)
            {
                double x = interval_min_x + i * step;
                double pdf = Normal.PDF(x_avg, Math.Sqrt(disp), x) * scale_factor;
                pdfSeries.Points.AddXY(x, pdf);
            }

            chart.Series.Add(pdfSeries);

            chartArea.AxisX.Title = "Значения";
            chartArea.AxisY.Title = "Относительная частота";
            chart.Titles.Clear();
            chart.Titles.Add("Гистограмма и нормальная кривая");
            chart.Legends.Clear();
            chart.Legends.Add(new Legend());
            chart.Legends[0].Docking = Docking.Top;

            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisX.Minimum = interval_min_x - midDiff / 2; 
            chartArea.AxisX.Maximum = interval_max_x + midDiff / 2; 

            chartArea.AxisX.CustomLabels.Clear();
            for (int i = 0; i < intervals_centers.Count; i++)
            {
                double labelPosition = intervals_centers[i];
                chartArea.AxisX.CustomLabels.Add(
                    labelPosition - midDiff / 2,
                    labelPosition + midDiff / 2, 
                    intervals_centers[i].ToString("F1") 
                );
            }

            chartArea.AxisX.MajorTickMark.Interval = midDiff;
        }

    }
}
