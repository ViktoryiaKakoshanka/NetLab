using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greatest_Common_Divisor.Model
{
    class BarChart
    {
        enum BarChartAlign
        {
            Vertical,
            Horizontal
        };

        private Color Color { get; set; }
        private int _iterations;
        private BarChartAlign Align { get; set; }

        private Dictionary<int, int[]> intermediateData = new Dictionary<int, int[]>();

        public void Add(int step, int a, int b)
        {
            intermediateData.Add(step, new[] { a, b });
        }

        BarChart(int steps, Color color, BarChartAlign align = BarChartAlign.Vertical)
        {
            _iterations = steps;
            Color = color;
            Align = align;
        }
    }
}
