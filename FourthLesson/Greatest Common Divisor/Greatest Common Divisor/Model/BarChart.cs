using System.Drawing;

namespace GreatestCommonDivisorProgram.Model
{
    public class BarChart
    {
        public enum BarChartAlign
        {
            Vertical,
            Horizontal
        };

        public BarChart()
        {
            Color = Color.Red;
            Align = BarChartAlign.Vertical;
        }

        public Color Color { get; set; }
        public int Iterations { get; set; }
        public BarChartAlign Align { get; set; }

    }
}
