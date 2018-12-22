using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using Greatest_Common_Divisor.Model;

namespace Greatest_Common_Divisor.View
{
    internal class BarChartView
    {
        public void Initialize(Chart chart, BarChart barChart)
        {
            SetInitialParameters(chart, barChart.Color, barChart.ChartType);
            FillChartWithHistory(chart, barChart.CalculationHistory);            
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

            chart.Series.Add("Number А");
            chart.Series.Add("Number В");

            chart.Series["Number А"].ChartType = chartType;
            chart.Series["Number В"].ChartType = chartType;
        }

        private static void FillChartWithHistory(Chart chart, IDictionary<int, int[]> data)
        {
            foreach (var item in data)
            {
                chart.Series["Number А"].Points.AddY(item.Value[0]);
                chart.Series["Number В"].Points.AddY(item.Value[1]);
            }
        }
    }
}
