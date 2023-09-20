using System;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {


        private double accumulator = 0;
        private char lastOperation;
        public Form1()
        {
            InitializeComponent();
        }
        private void Operator_Pressed(object sender, EventArgs e)
        {
            // An operator was pressed; perform the last operation
            // and store the new operator.
            char operation = (sender as Button).Text[0];
            if (operation == 'C')
            {
                accumulator = 0;
            }

            else
            {
                double currentValue = double.Parse(Display.Text);
                switch (lastOperation)
                {
                    case '+': accumulator += currentValue; break;
                    case '-': accumulator -= currentValue; break;
                    case '�': accumulator *= currentValue; break;
                    case '�': accumulator /= currentValue; break;
                    default: accumulator = currentValue; break;
                }

            }
            lastOperation = operation;
            Display.Text = operation == '=' ?
           accumulator.ToString() : "0";
        }
        private void Number_Pressed(object sender, EventArgs e)
        {
            // Add it to the display.
            string number = (sender as Button).Text;
            Display.Text = Display.Text == "0" ? number :
           Display.Text + number;
        }
        private void Trigonometric_function(object sender, EventArgs e)
        {
            string operation = (sender as Button).Text;
            double currentValue = double.Parse(Display.Text);

            switch (operation.ToString())
            {

                case "Sin": Display.Text = Math.Sin(currentValue).ToString(); break;
                case "Cos": Display.Text = Math.Cos(currentValue).ToString(); break;
                case "Tan": Display.Text = Math.Tan(currentValue).ToString(); break;
                case "Cot": Display.Text = (1 / Math.Tan(currentValue)).ToString(); break;
                case "Sec": Display.Text = (1 / Math.Cos(currentValue)).ToString(); break;
                case "Cosec": Display.Text = (1 / Math.Sin(currentValue)).ToString(); break;


            }
            //Display.Text = operation == "=" ?
            //accumulator.ToString() : "0";
        }


    }
}