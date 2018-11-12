using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Greatest_Common_Divisor.Controller;
using Greatest_Common_Divisor.Model;
using GreatestCommonDivisor.Model;
using GreatestCommonDivisorProgram.Model;
using GreatestCommonDivisorProgram.View;

namespace GreatestCommonDivisorProgram
{
    public partial class Form1 : Form
    {
        BarChartView chart = new BarChartView();
        GcdResult gcdResult = new GcdResult();
        private string _result = "";
        
        public Form1()
        {
            InitializeComponent();

            comboPalette.Items.AddRange(chart.GetPalette());
            comboPalette.SelectedIndex = 11;

            comboTypeChart.Items.AddRange(chart.GetSeriesChartType());
            comboTypeChart.SelectedIndex = 10;

            groupResults.Click += new System.EventHandler(this.groupResults_Click);
        }

        public string PrintResult()
        {
            return _result;
        }

        public void ShowWarningMessage()
        {
            MessageBox.Show("Числа должны быть целыми и отделяться пробелами. Введите числа заново.");
        }

        public void ReadUserInputAndWriteResult(string userInput, GcdAlgorithmType algorithmType)
        {
            if (ValidateUserInt(userInput))
            {
                gcdResult.ClearCalculationHistory();
                var arrNumbers = ParseUserInput(userInput);

                EnableCreatingChart(arrNumbers.Length);
                RunAlgoritmGcd(algorithmType, arrNumbers);
                GetFormatedResult(arrNumbers);
            }
            else
            {
                ShowWarningMessage();
            }
        }

        private void RunAlgoritmGcd(GcdAlgorithmType algorithmType, int[] arrNumbers)
        {
            if (algorithmType == GcdAlgorithmType.Euclidian)
            {
                RunGCDEuclidean(arrNumbers);
            }
            else
            {
                RunGCDStain(arrNumbers);
            }
        }

        private void groupResults_Click(object sender, EventArgs e)
        {
            lblresult.Text = String.Empty;
        }

        private void CreateBarCharOnClick(object sender, EventArgs e)
        {
            var colorPalette = (ChartColorPalette)Enum.Parse(typeof(ChartColorPalette), comboPalette.Text);
            var typeChart = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), comboTypeChart.Text);
            var barChart = new BarChart(gcdResult.GetCalculationHistory(), colorPalette, typeChart);
            chart.Initialize(chart1, barChart);
            createBarChar.Enabled = false;
        }
        
        private static bool ValidateUserInt(string userInput)
        {
            var regex = new Regex(@"^[-+]?[0-9]{1,3} [-+]?[0-9]{1,3}( [-+]?[0-9]{1,3})?( [-+]?[0-9]{1,3})?( [-+]?[0-9]{1,3})?$");
            return (regex.IsMatch(userInput));
        }

        private int[] ParseUserInput(string userInput)
        {
            var arr = userInput.Split(' ');
            var arrResult = new int[arr.Length];

            for (var i = 0; i < arr.Length; i++)
            {
                arrResult[i] = Convert.ToInt32(arr[i]);
            }

            return arrResult;
        }

        private void GetFormatedResult(int[] numbers)
        {
            var s = new StringBuilder();
            s.AppendFormat("{0}", "НОД( ");
            foreach (var item in numbers)
            {
                s.AppendFormat("{0} ", item.ToString());
            }
            s.Append($") = {gcdResult.Gcd}");
            s.Append((gcdResult.IterationsCount == 0) ? "\n" : $" и кол-во итераций = {gcdResult.IterationsCount}\n");
            _result = s.ToString();
        }

        private void GCDEuclideOnClick(object sender, EventArgs e)
        {
            ReadUserInputAndWriteResult(numbersForGCD.Text, GcdAlgorithmType.Euclidian);
            lblresult.Text += PrintResult();
        }

        private void GCDStain_Click(object sender, EventArgs e)
        {
            ReadUserInputAndWriteResult(numbersForGCD.Text, GcdAlgorithmType.Stain);
            lblresult.Text += PrintResult();
        }

        private void RunGCDEuclidean(int[] userNumbers)
        {
            gcdResult = new EuclideanGcdAlgorithm().Calculate(userNumbers);
        }

        private void RunGCDStain(int[] userNumbers)
        {
            gcdResult = new StainGcdAlgorithm().Calculate(userNumbers);
        }

        private void EnableCreatingChart(int countNumbers)
        {
            createBarChar.Enabled = (countNumbers == 2) ? true : false;
        }
    }
}
