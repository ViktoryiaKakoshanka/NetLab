using System.Collections.Generic;
using System.Drawing;

namespace Greatest_Common_Divisor.Model
{
    class BarChart
    {
        private Color Color { get; set; }
        private int _iterations;
        private BarChartType Align { get; set; }

        private Dictionary<int, int[]> intermediateData = new Dictionary<int, int[]>();

        public void Add(int step, int a, int b)
        {
            intermediateData.Add(step, new[] { a, b });
        }

        BarChart(int steps, Color color, BarChartType align = BarChartType.Vertical)
        {
            _iterations = steps;
            Color = color;
            Align = align;
        }
    }
}
