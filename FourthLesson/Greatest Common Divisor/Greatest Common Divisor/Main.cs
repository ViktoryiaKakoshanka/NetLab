using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Greatest_Common_Divisor.Model;
using Greatest_Common_Divisor.View;

namespace Greatest_Common_Divisor
{
    public partial class Form1 : Form
    {
        private readonly BarChartView _chartView = new BarChartView();
        private GcdResult _result = new GcdResult();
        
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
            var barChart = new BarChart(_result.GetCalculationHistory(), colorPalette, typeChart);

            _chartView.Initialize(chart, barChart);
            createBarChar.Enabled = false;
        }

        private string GetUserInput()
        {
            return numbersForGCD.Text;
        }

        private void AlgorithmEuclideanOnClick(object sender, EventArgs e)
        {
            if (!ValidateUserInput(GetUserInput()))
            {
                ShowWarningMessage();
                return;
            }
            RunAlgorithm(AlgorithmType.Euclidean);
        }


        private void AlgorithmStainOnClick(object sender, EventArgs e)
        {
            if (!ValidateUserInput(GetUserInput()))
            {
                ShowWarningMessage();
                return;
            }
            RunAlgorithm(AlgorithmType.Stain);
        }
        
        private void RunAlgorithm(AlgorithmType algorithmType)
        {
            var numbers = ParseUserInput(GetUserInput());
            _result = Driver.Calculate(numbers, algorithmType);

            EnableCreatingChart(numbers.Length);
            lblresult.Text += Driver.FormatResult(numbers, _result);
        }

        private void EnableCreatingChart(int countNumbers)
        {
            createBarChar.Enabled = countNumbers == 2;
        }

        private static bool ValidateUserInput(string userInput)
        {
            var regex = new Regex(@"^[-+]?[0-9]{1,3} [-+]?[0-9]{1,3}( [-+]?[0-9]{1,3})?( [-+]?[0-9]{1,3})?( [-+]?[0-9]{1,3})?$");
            return regex.IsMatch(userInput);
        }

        private static int[] ParseUserInput(string userInput)
        {
            return userInput.Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
        }

        public void ShowWarningMessage()
        {
            MessageBox.Show(@"Numbers must be integers and separated by spaces. Enter the numbers again.");
        }

        private void GroupResultsOnClick(object sender, EventArgs e)
        {
            lblresult.Text = string.Empty;
        }
    }
}
