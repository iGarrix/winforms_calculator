namespace Calc
{
    public partial class Form1 : Form
    {
        private double currentValue = 0;
        private string currentOperator = "";
        private bool isNewNumber = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void numberButton_Click(object sender, EventArgs e)
        {
            if (isNewNumber)
            {
                tb.Text = "";
                isNewNumber = false;
            }

            Button button = (Button)sender;
            tb.Text += button.Text;
        }

        private void operation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string newOperator = button.Text;

            if (!isNewNumber)
            {
                Calculate();
                currentOperator = newOperator;
                isNewNumber = true;
            }
            else
            {
                currentOperator = newOperator;
            }
        }

        private void equal_Click(object sender, EventArgs e)
        {
            Calculate();
            currentOperator = "";
            isNewNumber = true;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            currentValue = 0;
            currentOperator = "";
            tb.Text = "0";
            isNewNumber = true;
        }

        private void Calculate()
        {
            double newValue = double.Parse(tb.Text);

            switch (currentOperator)
            {
                case "+":
                    currentValue += newValue;
                    break;
                case "-":
                    currentValue -= newValue;
                    break;
                case "*":
                    currentValue *= newValue;
                    break;
                case "/":
                    currentValue /= newValue;
                    break;
                case "√":
                    currentValue = Math.Sqrt(currentValue);
                    break;
                case "x²":
                    currentValue *= currentValue;
                    break;
                default:
                    currentValue = newValue;
                    break;
            }

            tb.Text = currentValue.ToString();
        }

        private void specOperations_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string newOperator = button.Text;
            if (!isNewNumber)
            {
                currentOperator = newOperator;
                isNewNumber = true;
            }
            else
            {
                currentOperator = newOperator;
            }

            double newValue = double.Parse(tb.Text);

            switch (currentOperator)
            {
                case "√":
                    newValue = Math.Sqrt(newValue);
                    break;
                case "x²":
                    newValue *= newValue;
                    break;
                default:
                    newValue = -1;
                    break;
            }
            currentValue = newValue;
            tb.Text = currentValue.ToString();
        }

        private void revert_Click(object sender, EventArgs e)
        {
            double value = double.Parse(tb.Text);
            value -= value * 2;
            tb.Text = value.ToString();
        }

        private void comma_Click(object sender, EventArgs e)
        {
            tb.Text += ",";
        }
    }
}
