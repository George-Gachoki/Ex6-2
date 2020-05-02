using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutureValue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
/* Exercise 6-1 Enhance the Future Value application - George Gachoki, 04/23/2020
 * ------------------------------------------------------------------------------   */
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal monthlyInvestment = Convert.ToDecimal(txtMonthlyInvestment.Text);
            decimal yearlyInterestRate = Convert.ToDecimal(txtInterestRate.Text);
            int years = Convert.ToInt32(txtYears.Text);

            int months = years * 12;
            decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;
            decimal futureValue = CalculateFutureValue(monthlyInvestment, months, monthlyInterestRate);

            txtFutureValue.Text = futureValue.ToString("c");
            txtMonthlyInvestment.Focus();
        }

        private static decimal CalculateFutureValue(decimal monthlyInvestment, int months, decimal monthlyInterestRate)
        {
            decimal futureValue = 0m;
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + monthlyInvestment)
                            * (1 + monthlyInterestRate);
            }

            return futureValue;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

/* Exercise 6-2 Experiment with Events - George Gachoki, 04/23/2020
   * ------------------------------------------------------------------------------   */
        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            // clear text boxes on doubleclicking on the form
            txtMonthlyInvestment.Text = "";
            txtInterestRate.Text = "";
            txtYears.Text = "";
            txtFutureValue.Text = "";
        }

        private void ClearFutureValue(object sender, EventArgs e)
        {
            txtFutureValue.Text = "";
        }

        private void txtInterestRate_DoubleClick(object sender, EventArgs e)
        {
            txtInterestRate.Text = "12";
        }
    }
}