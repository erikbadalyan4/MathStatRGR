using MathStatRGR.Utils;
using MetroFramework.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace MathStatRGR.Pages
{
    class StatisticalEstimatesAndHypothesesPage: MetroTabPage
    {
        public StatisticalEstimatesAndHypothesesPage() 
        {
            Text = "Статистические оценки и гипотезы";

            Controls.Add(new StatisticalEstimatesAndHypothesesControls());
            
        }
    }
}
