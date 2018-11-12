using GreatestCommonDivisorProgram.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace GreatestCommonDivisorProgram.View
{
    class BarChartView
    {
        public void Initialize(Chart chart, BarChart barChart)
        {
            SetInitialParameters(chart, barChart.Color, barChart.ChartType);
            FillTheChartWithHistory(chart, barChart.CalculationHistory);            
        }

        public string[] GetPalette()
        {
            return Enum.GetNames(typeof(ChartColorPalette));
        }

        public string[] GetSeriesChartType()
        {
            return Enum.GetNames(typeof(SeriesChartType));
        }

        private void SetInitialParameters(Chart chart, ChartColorPalette colorPalette, SeriesChartType chartType)
        {
            chart.Series.Clear();
            chart.Palette = colorPalette;

            chart.Series.Add("Number А");
            chart.Series.Add("Number В");

            chart.Series["Number А"].ChartType = chartType;
            chart.Series["Number В"].ChartType = chartType;
        }

        private void FillTheChartWithHistory(Chart chart, IDictionary<int, int[]> data)
        {
            foreach (var item in data)
            {
                chart.Series["Number А"].Points.AddY(item.Value[0]);
                chart.Series["Number В"].Points.AddY(item.Value[1]);
            }
        }


    }
}
