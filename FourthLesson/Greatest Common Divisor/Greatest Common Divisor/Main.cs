using System;
using System.Windows.Forms;
using GreatestCommonDivisorProgram.View;

namespace GreatestCommonDivisorProgram
{
    public partial class Form1 : Form
    {
        UserInputOfNumbers viewInputNumbers = new UserInputOfNumbers();
        

        public Form1()
        {
            InitializeComponent();
            this.groupResults.Click += new System.EventHandler(this.groupResults_Click);
        }

        private void GCDEuclide_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            viewInputNumbers.ReadUserInputAndWriteResult(numbersForGCD.Text, button.Name);
            lblresult.Text += viewInputNumbers.PrintResult();
        }

        private void groupResults_Click(object sender, EventArgs e)
        {
            lblresult.Text = "";
        }
    }
}
