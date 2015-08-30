using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class frmCalculator : Form
    {
        // initializing variables
        public bool nonNumericEntered = false;
        public string lastValue = "";
        public char currentOperator = ' ';
        public char currentValue = ' ';
        public frmCalculator()
        {
            InitializeComponent();
        }

        private void frmCalculator_Load(object sender, EventArgs e)
        {
            // initializing the textbox and label value to empty
            lblOutput.Text = string.Empty;
            txtDisplay.Text = string.Empty;
        }

        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {
            // condition to evaluate the more than one operation on given input
            if (currentOperator != ' ' && currentOperator == currentValue && lblOutput.Text != string.Empty)
            {
                lastValue = lblOutput.Text;
                txtDisplay.Text = lastValue + currentOperator;
                lblOutput.Text = "";
            }
            else
                lastValue = txtDisplay.Text;

            // condtion to check the operands to do arithmetic operations
            if ((txtDisplay.TextLength > 0) && (currentOperator != ' ') && (currentOperator != currentValue))
            {
                lblOutput.Text = InputProcessor(txtDisplay.Text);
            }
        }

        private void txtDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Non-numeric values should not display in textbox
            // to skip those entry used Handled property 
            e.Handled = nonNumericEntered;
            if (!nonNumericEntered)
                currentValue = e.KeyChar;
        }

        private void txtDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumericEntered = false;
            // Key codes to verify the keys enter thru keyboard
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    nonNumericEntered = true;
                }
            }
            // todo:: add code to accept the operator thru keyboard
        }

        private string InputProcessor(string input)
        {
            // to get the operators index in the given input
            // Ex: input = "12453+566"
            // operator position in 6th position
            // to split the input into two operands and do our operations

            var operatorIndex = input.IndexOf(currentOperator);
            var a = Int64.Parse(input.Substring(0, operatorIndex));
            var b = Int64.Parse(input.Substring(operatorIndex + 1, input.Length - (operatorIndex + 1)));

            string result = string.Empty;
            switch (currentOperator)
            {
                case '+':
                    return (a + b).ToString();
                case '-':
                    return (a - b).ToString();
                case '*':
                    return (a * b).ToString();
                case '/':
                    //todo: Handle 1/0 problem
                    return (a / b).ToString();
                default:
                    return "";
            }
        }

        #region Form Button 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDisplay.TextLength > 0)
            {
                currentOperator = '+';
                currentValue = '+';
                txtDisplay.AppendText("+");
            }
            txtDisplay.Focus();
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            // add ur code to handle the input for subtractions
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            // add ur code to handle the input for multiplication
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            // add ur code to handle the input for Division
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "";
            lblOutput.Text = "";
            currentValue = ' ';
            currentOperator = ' ';
            lastValue = string.Empty;

        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            currentValue = '1';
            txtDisplay.AppendText("1");
            txtDisplay.Focus();
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            currentValue = '2';
            txtDisplay.AppendText("2");
            txtDisplay.Focus();
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            currentValue = '3';
            txtDisplay.AppendText("3");
            txtDisplay.Focus();
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            currentValue = '4';
            txtDisplay.AppendText("4");
            txtDisplay.Focus();
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            currentValue = '5';
            txtDisplay.AppendText("5");
            txtDisplay.Focus();
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            currentValue = '6';
            txtDisplay.AppendText("6");
            txtDisplay.Focus();
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            currentValue = '7';
            txtDisplay.AppendText("7");
            txtDisplay.Focus();
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            currentValue = '8';
            txtDisplay.AppendText("8");
            txtDisplay.Focus();
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            currentValue = '9';
            txtDisplay.AppendText("9");
            txtDisplay.Focus();
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            currentValue = '0';
            txtDisplay.AppendText("0");
            txtDisplay.Focus();
        }



        #endregion

    }
}
