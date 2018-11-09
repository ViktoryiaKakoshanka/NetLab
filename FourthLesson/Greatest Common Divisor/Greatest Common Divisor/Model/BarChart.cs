using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace GreatestCommonDivisorProgram.Model
{
    public class BarChart
    {
        public ChartColorPalette Color { get; set; }
        public SeriesChartType ChartType { get; set; }
        public IDictionary<int, int[]> CalculationHistory { get; set; }

        public BarChart(IDictionary<int, int[]> calculationHistory, ChartColorPalette chartColorPalette = ChartColorPalette.SeaGreen, SeriesChartType chartType = SeriesChartType.Bar)
        {
            CalculationHistory = calculationHistory;
            Color = chartColorPalette;
            ChartType = chartType;
        }
    }
}
