using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Greatest_Common_Divisor.Controller;
using Greatest_Common_Divisor.Model;
using Greatest_Common_Divisor.View;

namespace Greatest_Common_Divisor
{
    public partial class Form1 : Form
    {
        private readonly BarChartView _chart = new BarChartView();
        private GcdResult _result = new GcdResult();
        private string _formattedResult = "";
        
        public Form1()
        {
            InitializeComponent();

            comboPalette.Items.AddRange(_chart.GetPalette());
            comboPalette.SelectedIndex = 11;

            comboTypeChart.Items.AddRange(_chart.GetSeriesChartType());
            comboTypeChart.SelectedIndex = 10;

            groupResults.Click += GroupResultsOnClick;
        }

        public string PrintResult() => _formattedResult;

        public void ShowWarningMessage()
        {
            MessageBox.Show(@"Numbers must be integers and separated by spaces. Enter the numbers again.");
        }

        public void ReadUserInputAndWriteResult(string userInput, GcdAlgorithmType algorithmType)
        {
            if (ValidateUserInt(userInput))
            {
                _result.ClearCalculationHistory();
                var arrNumbers = ParseUserInput(userInput);

                EnableCreatingChart(arrNumbers.Length);
                RunAlgorithm(algorithmType, arrNumbers);
                GetFormattedResult(arrNumbers);
            }
            else
            {
                ShowWarningMessage();
            }
        }

        private void RunAlgorithm(GcdAlgorithmType algorithmType, int[] arrNumbers)
        {
            if (algorithmType == GcdAlgorithmType.Euclidean)
            {
                RunAlgorithmEuclidean(arrNumbers);
            }
            else
            {
                RunAlgorithmStain(arrNumbers);
            }
        }

        private void GroupResultsOnClick(object sender, EventArgs e)
        {
            lblresult.Text = string.Empty;
        }

        private void CreateBarCharOnClick(object sender, EventArgs e)
        {
            var colorPalette = (ChartColorPalette)Enum.Parse(typeof(ChartColorPalette), comboPalette.Text);
            var typeChart = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), comboTypeChart.Text);
            var barChart = new BarChart(_result.GetCalculationHistory(), colorPalette, typeChart);
            _chart.Initialize(chart1, barChart);
            createBarChar.Enabled = false;
        }
        
        private static bool ValidateUserInt(string userInput)
        {
            var regex = new Regex(@"^[-+]?[0-9]{1,3} [-+]?[0-9]{1,3}( [-+]?[0-9]{1,3})?( [-+]?[0-9]{1,3})?( [-+]?[0-9]{1,3})?$");
            return regex.IsMatch(userInput);
        }

        private static int[] ParseUserInput(string userInput)
        {
            var arr = userInput.Split(' ');
            var arrResult = new int[arr.Length];

            for (var i = 0; i < arr.Length; i++)
            {
                arrResult[i] = Convert.ToInt32(arr[i]);
            }

            return arrResult;
        }

        private void GetFormattedResult(int[] numbers)
        {
            var s = new StringBuilder();
            s.AppendFormat("{0}", "НОД( ");
            foreach (var item in numbers)
            {
                s.AppendFormat("{0} ", item.ToString());
            }
            s.Append($") = {_result.Gcd}");
            s.Append(_result.IterationsCount == 0 ? "\n" : $" and number of iterations = {_result.IterationsCount}\n");
            _formattedResult = s.ToString();
        }

        private void AlgorithmEuclideanOnClick(object sender, EventArgs e)
        {
            ReadUserInputAndWriteResult(numbersForGCD.Text, GcdAlgorithmType.Euclidean);
            lblresult.Text += PrintResult();
        }

        private void AlgorithmStainOnClick(object sender, EventArgs e)
        {
            ReadUserInputAndWriteResult(numbersForGCD.Text, GcdAlgorithmType.Stain);
            lblresult.Text += PrintResult();
        }

        private void RunAlgorithmEuclidean(int[] userNumbers)
        {
            _result = new EuclideanGcdAlgorithm().Calculate(userNumbers);
        }

        private void RunAlgorithmStain(int[] userNumbers)
        {
            _result = new StainGcdAlgorithm().Calculate(userNumbers);
        }

        private void EnableCreatingChart(int countNumbers)
        {
            createBarChar.Enabled = countNumbers == 2;
        }
    }
}
