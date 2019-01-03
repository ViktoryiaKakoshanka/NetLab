using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Greatest_Common_Divisor.Algorithms;
using Greatest_Common_Divisor.Model;
using Greatest_Common_Divisor.View;

namespace Greatest_Common_Divisor
{
    public partial class Form1 : Form
    {
        private readonly BarChartView _chartView = new BarChartView();
        private GcdResult _result;
        
        public Form1()
        {
            InitializeComponent();

            comboPalette.Items.AddRange(_chartView.GetPalette());
            comboPalette.SelectedIndex = 11;

            comboTypeChart.Items.AddRange(_chartView.GetSeriesChartType());
            comboTypeChart.SelectedIndex = 10;

            groupResults.Click += GroupResultsOnClick;
        }
        
        private void CreateBarCharOnClick(object sender, EventArgs e)
        {
            var colorPalette = (ChartColorPalette)Enum.Parse(typeof(ChartColorPalette), comboPalette.Text);
            var typeChart = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), comboTypeChart.Text);

            _chartView.Initialize(chart, colorPalette, typeChart, _result.GetCalculationHistory());
            createBarChar.Enabled = false;
        }

        private string GetUserInput()
        {
            return numbersForGCD.Text;
        }

        private void AlgorithmEuclideanOnClick(object sender, EventArgs e)
        {
            RunAlgorithm(AlgorithmType.Euclidean);
        }

        private void AlgorithmStainOnClick(object sender, EventArgs e)
        {
            RunAlgorithm(AlgorithmType.Stain);
        }
        
        private void RunAlgorithm(AlgorithmType algorithmType)
        {
            if (!ValidateUserInput(GetUserInput()))
            {
                ShowWarningMessage();
                return;
            }

            var numbers = ParseUserInput(GetUserInput());
            _result = AlgorithmHelper.Calculate(numbers, algorithmType);

            EnableCreatingChart(numbers.Length);
            lblresult.Text += FormatResult(numbers, _result);
        }

        private void EnableCreatingChart(int countNumbers)
        {
            createBarChar.Enabled = countNumbers == 2;
        }

        private void GroupResultsOnClick(object sender, EventArgs e)
        {
            lblresult.Text = string.Empty;
        }

        private static bool ValidateUserInput(string userInput)
        {
            var regex = new Regex(@"^[-+]?[1-9]{1,3} [-+]?[1-9]{1,3}( [-+]?[1-9]{1,3})?( [-+]?[1-9]{1,3})?( [-+]?[1-9]{1,3})?$");
            return regex.IsMatch(userInput);
        }

        private static int[] ParseUserInput(string userInput)
        {
            return userInput.Split(' ').Select(int.Parse).ToArray();
        }

        private static void ShowWarningMessage()
        {
            MessageBox.Show(@"Numbers must be integers and separated by spaces. Enter the numbers again.");
        }
        
        private static string FormatResult(IEnumerable<int> numbers, GcdResult result)
        {
            var s = new StringBuilder();

            s.Append("GCD( ")
                .Append(string.Concat(numbers.Select(x => $"{x.ToString()} ")))
                .Append($") = {result.GreatestCommonDivisor}")
                .Append(result.IterationsCount == 0 ? "\n" : $" and number of iterations = {result.IterationsCount}\n");

            return s.ToString();
        }
    }
}
