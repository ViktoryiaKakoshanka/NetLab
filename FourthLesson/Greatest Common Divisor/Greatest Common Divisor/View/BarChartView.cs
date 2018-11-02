using GreatestCommonDivisorProgram.Controller;
using GreatestCommonDivisorProgram.Model;
using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace GreatestCommonDivisorProgram.View
{
    class BarChartView
    {
        public void Initialize(Chart chart, string palette, string typeChart)
        {
            var barChart = new BarChart();
            var dataForChart = GreatestCommonDivisor.KeyValuePairs();
            
            chart.Series.Clear();

            chart.Palette = (ChartColorPalette)Enum.Parse(typeof(ChartColorPalette), palette);

            chart.Series.Add("Число А");
            chart.Series.Add("Число В");
            
            chart.Series["Число А"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), typeChart);
            chart.Series["Число В"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), typeChart);

            foreach(var item in dataForChart)
            {
                chart.Series["Число А"].Points.AddY(item.Value[0]);
                chart.Series["Число В"].Points.AddY(item.Value[1]);
            }

        }


        public string[] GetPalette()
        {
            return Enum.GetNames(typeof(ChartColorPalette));
        }


        public string[] GetSeriesChartType()
        {
            return Enum.GetNames(typeof(SeriesChartType));
        }

    }
}
