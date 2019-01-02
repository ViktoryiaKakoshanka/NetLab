using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace Greatest_Common_Divisor.View
{
    internal class BarChartView
    {
        private const string FirstNumber = "Number А";
        private const string SecondNumber = "Number B";

        public void Initialize(Chart chart, ChartColorPalette colorPalette, SeriesChartType chartType, IDictionary<int, int[]> data)
        {
            SetInitialParameters(chart, colorPalette, chartType);
            FillChartWithHistory(chart, data);            
        }

        public object[] GetPalette()
        {
            return Enum.GetNames(typeof(ChartColorPalette)).ToArray<object>();
        }

        public object[] GetSeriesChartType()
        {
            return Enum.GetNames(typeof(SeriesChartType)).ToArray<object>();
        }

        private static void SetInitialParameters(Chart chart, ChartColorPalette colorPalette, SeriesChartType chartType)
        {
            chart.Series.Clear();
            chart.Palette = colorPalette;

            chart.Series.Add(FirstNumber);
            chart.Series.Add(SecondNumber);

            chart.Series[FirstNumber].ChartType = chartType;
            chart.Series[SecondNumber].ChartType = chartType;
        }

        private static void FillChartWithHistory(Chart chart, IDictionary<int, int[]> data)
        {
            foreach (var item in data)
            {
                chart.Series[FirstNumber].Points.AddY(item.Value[0]);
                chart.Series[SecondNumber].Points.AddY(item.Value[1]);
            }
        }
    }
}
