using System;
using System.Windows.Forms;

namespace CalculatorForm
{
    public partial class CalculatorForm : Form
    {
        private CalculatorNumber firstNumber = new CalculatorNumber();
        private CalculatorNumber secondNumber = new CalculatorNumber();
        private CalculatorNumber answer = new CalculatorNumber();
        private string sign = string.Empty;

        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void PrintInputs()
        {
            tb_ans.Clear();
            tb_ans.Text = answer.GetStringValue();

            tb_inp.Clear();
            tb_inp.Text = firstNumber.GetStringValue();
            tb_inp.Text += sign;
            tb_inp.Text += secondNumber.GetStringValue();
        }

        private void Solve()
        {
            if (secondNumber.IsUsed())
            {
                switch (sign)
                {
                    case OperatorSigns.divide:
                        SafeDivide();
                        break;
                    case OperatorSigns.multiply:
                        answer.SetNumber(firstNumber.GetValue() * secondNumber.GetValue());
                        break;
                    case OperatorSigns.add:
                        answer.SetNumber(firstNumber.GetValue() + secondNumber.GetValue());
                        break;
                    case OperatorSigns.subtract:
                        answer.SetNumber(firstNumber.GetValue() - secondNumber.GetValue());
                        break;
                }

                tb_ans.Clear();
                tb_ans.Text = answer.GetStringValue();
            }
        }

        private void SafeDivide()
        {
            if (secondNumber.GetValue() != 0)
            {
                answer.SetNumber(firstNumber.GetValue() / secondNumber.GetValue());
            }
            else if (secondNumber.GetValue() == 0 && firstNumber.GetValue() == 0)
            {
                answer.SetError("Indeterminate form");
                SetErrorLock(true);
            }
            else
            {
                answer.SetError("Division by zero");
                SetErrorLock(true);
            }
        }

        private void SetErrorLock(bool enableControl)
        {
            btn_0.Enabled = !enableControl;
            btn_1.Enabled = !enableControl;
            btn_2.Enabled = !enableControl;
            btn_3.Enabled = !enableControl;
            btn_4.Enabled = !enableControl;
            btn_5.Enabled = !enableControl;
            btn_6.Enabled = !enableControl;
            btn_7.Enabled = !enableControl;
            btn_8.Enabled = !enableControl;
            btn_9.Enabled = !enableControl;
            btn_Divide.Enabled = !enableControl;
            btn_Add.Enabled = !enableControl;
            btn_Subtract.Enabled = !enableControl;
            btn_Multiply.Enabled = !enableControl;
            btn_Comma.Enabled = !enableControl;
            btn_Execute.Enabled = !enableControl;
        }

        private void SetSign(string signInput)
        {
            if (answer.HasErrorValue())
            {
                return;
            }

            if (answer.IsUsed())
            {
                firstNumber.SetNumber(answer.GetValue());
                secondNumber.Clear();
                answer.Clear();
                this.sign = signInput;
            }
            else if (firstNumber.IsUsed())
            {
                this.sign = signInput;
            }

            PrintInputs();
        }

        private void AddDigit(int input)
        {
            if (answer.HasErrorValue())
            {
                return;
            }

            if (!answer.IsUsed())
            {
                if (!string.IsNullOrEmpty(sign))
 
                {
                    secondNumber.AddDigit(input);
                }
                else
                {
                    firstNumber.AddDigit(input);
                }

                PrintInputs();
            }
            else
            {
                Clear();
                firstNumber.AddDigit(input);

                PrintInputs();
            }
        }

        private void SetComma()
        {
            if (!answer.IsUsed())
            {
                if (!string.IsNullOrEmpty(sign))
                {
                    secondNumber.TurnOnDecimal();
                }
                else
                {
                    firstNumber.TurnOnDecimal();
                }
            }
        }

        private void Clear()
        {
            tb_ans.Clear();
            tb_inp.Clear();

            firstNumber.Clear();
            secondNumber.Clear();
            answer.Clear();
            sign = string.Empty;
            SetErrorLock(false);
        }

        private void Btn_C_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            AddDigit(0);
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            AddDigit(1);
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            AddDigit(2);
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            AddDigit(3);
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            AddDigit(4);
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            AddDigit(5);
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            AddDigit(6);
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            AddDigit(7);
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            AddDigit(8);
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            AddDigit(9);
        }

        private void btn_Divide_Click(object sender, EventArgs e)
        {
            SetSign(OperatorSigns.divide);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            SetSign(OperatorSigns.add);
        }

        private void btn_Subtract_Click(object sender, EventArgs e)
        {
            SetSign(OperatorSigns.subtract);
        }

        private void btn_Multiply_Click(object sender, EventArgs e)
        {
            SetSign(OperatorSigns.multiply);
        }

        private void btn_Dot_Click(object sender, EventArgs e)
        {
            SetComma();
        }

        private void btn_Execute_Click(object sender, EventArgs e)
        {
            Solve();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }

}
