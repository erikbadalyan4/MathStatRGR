using MetroFramework.Controls;

namespace MathStatRGR.Pages
{
    /// <summary>
    /// Представляет вкладку для анализа вариационных рядов.
    /// </summary>
    public class VarSeriesPage : MetroTabPage
    {
        public VarSeriesPage()
        {
            Text = "Вариационные ряды";
            var controls = new VarSeriesControls
            {
                Dock = System.Windows.Forms.DockStyle.Fill
            };
            Controls.Add(controls);
        }
    }
}