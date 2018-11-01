using System;
using System.Windows.Forms;
using Greatest_Common_Divisor.GCDAlgorithm;
using GreatestCommonDivisorProgram.View;

namespace GreatestCommonDivisorProgram
{
    public partial class Form1 : Form
    {
        GcdCalculationDriver viewInputNumbers = new GcdCalculationDriver();

        public Form1()
        {
            InitializeComponent();
            this.groupResults.Click += new System.EventHandler(this.groupResults_Click);
        }

        private void GCDEuclide_Click(object sender, EventArgs e)
        {
            viewInputNumbers.CalculateGcd(numbersForGCD.Text, GcdAlgorithmType.Euclidian);

            if(viewInputNumbers.Result == null)
            {
                ShowWarningMessage();
                return;
            }

            lblresult.Text += viewInputNumbers.GetFormatedResult();
        }

        private void GCDStain_Click(object sender, EventArgs e)
        {
            viewInputNumbers.CalculateGcd(numbersForGCD.Text, GcdAlgorithmType.Stain);

            if (viewInputNumbers.Result == null)
            {
                ShowWarningMessage();
                return;
            }

            lblresult.Text += viewInputNumbers.GetFormatedResult();
        }

        private void groupResults_Click(object sender, EventArgs e)
        {
            lblresult.Text = string.Empty;
        }

        private void ShowWarningMessage()
        {
            MessageBox.Show("Числа должны быть целыми и отделяться пробелами. Введите числа заново.");
        }
    }
}
