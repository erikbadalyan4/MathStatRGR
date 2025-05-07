using MetroFramework.Controls;

namespace MathStatRGR.Pages
{
    public class AnovaPage : MetroTabPage
    {
        public AnovaPage()
        {
            Text = "Дисперсионный анализ";
            var controls = new AnovaControls
            {
                Dock = System.Windows.Forms.DockStyle.Fill
            };
            Controls.Add(controls);
        }
    }
}