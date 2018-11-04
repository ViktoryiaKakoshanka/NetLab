using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace GreatestCommonDivisorProgram.Model
{
    public class BarChart
    {
        public enum BarChartAlign
        {
            Vertical,
            Horizontal
        };

        public BarChart(ChartColorPalette chartColorPalette = ChartColorPalette.SeaGreen)
        {
            Color = chartColorPalette;
            Align = BarChartAlign.Vertical;
        }

        public ChartColorPalette Color { get; set; }
        public BarChartAlign Align { get; set; }
        private IDictionary<int, int[]> calculationHistory;

    }
}
