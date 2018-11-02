using System;
using System.Windows.Forms;
using GreatestCommonDivisorProgram.View;

namespace GreatestCommonDivisorProgram
{
    public partial class Form1 : Form
    {
        UserInputOfNumbers viewInputNumbers = new UserInputOfNumbers();
        BarChartView chart = new BarChartView();


        public Form1()
        {
            InitializeComponent();

            comboPalette.Items.AddRange(chart.GetPalette());
            comboPalette.SelectedIndex = 11;

            comboTypeChart.Items.AddRange(chart.GetSeriesChartType());
            comboTypeChart.SelectedIndex = 10;

            this.groupResults.Click += new System.EventHandler(this.groupResults_Click);
        }

        private void GCD_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            viewInputNumbers.ReadUserInputAndWriteResult(numbersForGCD.Text, button.Name);
            lblresult.Text += viewInputNumbers.PrintResult();
            createBarChar.Enabled = true;
        }

        private void groupResults_Click(object sender, EventArgs e)
        {
            lblresult.Text = "";
        }

        private void createBarChar_Click(object sender, EventArgs e)
        {
            chart.Initialize(chart1, comboPalette.Text, comboTypeChart.Text);
        }
        
    }
}
