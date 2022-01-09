using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator2
{
    public partial class Form1 : Form
    {

        private string comma = (Convert.ToString(0.1)).Substring(1);
        //private Boolean isListExpandRequired = true;
        private Double decimals = 0;
        List<String> Values = new List<String>();
        List<string> operators = new List<string>();

        private CalculatorNumber num1 = new CalculatorNumber();
        private CalculatorNumber num2 = new CalculatorNumber();
        private string sign="";
        private Boolean solved = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void PrintInputs()
        {
            tb_ans.Clear();
            tb_inp.Clear();

            tb_inp.Clear();
            tb_inp.Text = num1.StringValue();
            tb_inp.Text += sign;
            tb_inp.Text += num2.StringValue();
        }

        private void Solve()
        {
            double tempValue1;

            if (num2.IsUsed())
            {
                tempValue1 = 0;

                switch (sign)
                {
                    case "/":
                        tempValue1 = num1.Value() / num2.Value();
                        break;
                    case "*":
                        tempValue1 = num1.Value() * num2.Value();
                        break;
                    case "+":
                        tempValue1 = num1.Value() + num2.Value();
                        break;
                    case "-":
                        tempValue1 = num1.Value() - num2.Value();
                        break;
                }

                tb_ans.Clear();
                tb_ans.Text = Convert.ToString(tempValue1);
                solved= true;

            } 
        }

        private void AddInput(string inp1)
        {

            if (solved)
            {
                num1.AddInput(num2.Value());
                num2.Clear();
                sign = inp1;
                solved = false;
            }
            else if(num1.IsUsed())
            {
                sign = inp1;
            }

            PrintInputs();
        }

        private void AddInput(double inp1)
        {
            if (!solved)
            {
                if (sign != "")
                {
                    num2.AddInput(Convert.ToByte(inp1));
                }
                else
                {
                    num1.AddInput(Convert.ToByte(inp1));
                }

                PrintInputs();
            }
            
            
        }

        private void Btn_C_Click(object sender, EventArgs e)
        {
            tb_ans.Clear();
            tb_inp.Clear();

            num1.Clear();
            num2.Clear();
            sign = "";
            solved = false;

    }

        private void btn_0_Click(object sender, EventArgs e) => AddInput(0);
        private void btn_1_Click(object sender, EventArgs e) => AddInput(1);
        private void btn_2_Click(object sender, EventArgs e) => AddInput(2);
        private void btn_3_Click(object sender, EventArgs e) => AddInput(3);
        private void btn_4_Click(object sender, EventArgs e) => AddInput(4);
        private void btn_5_Click(object sender, EventArgs e) => AddInput(5);
        private void btn_6_Click(object sender, EventArgs e) => AddInput(6);
        private void btn_7_Click(object sender, EventArgs e) => AddInput(7);
        private void btn_8_Click(object sender, EventArgs e) => AddInput(8);
        private void btn_9_Click(object sender, EventArgs e) => AddInput(9);

        private void btn_Div_Click(object sender, EventArgs e) => AddInput("/");
        private void btn_Add_Click(object sender, EventArgs e) => AddInput("+");
        private void btn_Min_Click(object sender, EventArgs e) => AddInput("-");
        private void btn_Mul_Click(object sender, EventArgs e) => AddInput("*");

        private void btn_Dot_Click(object sender, EventArgs e)
        {
            //if (decimals == 0 && Values.Count >0) { decimals = 1; }
            if (!solved)
            {
                if (sign != "")
                {
                    num2.TurnOnDecimal();
                }
                else
                {
                    num1.TurnOnDecimal();
                }
            }
            
        }


        private void btn_Ans_Click(object sender, EventArgs e) => Solve();

        

    }

    public class CalculatorNumber
    {
        private Boolean isUsed = false;
        private long decimals = 0;
        private double num=0;
        private long additionalZeros;

        public CalculatorNumber()
        {

        }

        public void Clear()
        {
            isUsed = false;
            decimals = 0;
            num = 0;
            additionalZeros = 0;
        }


        public string StringValue()
        {
            string comma = (Convert.ToString(0.1)).Substring(1,1);
            string outstring;

            if (isUsed == false)
            {
                return "";
            }
            else
            {
                outstring = Convert.ToString(num);

                if (decimals >0 && decimals == additionalZeros+1)
                {
                    outstring += comma;
                }
                
                for(int i = 0; i < additionalZeros; i++)
                {
                    outstring += "0";
                }
                
                    
                return outstring;
            }
        }

        public Double Value() 
        { 
            return num;
        }

        public void AddInput(byte inp)
        {
            isUsed = true;

            if (decimals > 0)
            {

                if (inp == 0 )
                {
                    additionalZeros++;
                }
                else
                {
                    num += inp * Math.Pow(0.1, decimals);
                    additionalZeros = 0;
                }

                decimals++;
            }
            else
            {
                num = num * 10 + inp;
            }
        }

        public void AddInput(double inp)
        {
            isUsed = true;
            additionalZeros = 0;
            num = inp;
            decimals = 0;
        }

        public void TurnOnDecimal()
        {
            if (decimals == 0) { decimals = 1; }
        }

        public Boolean IsUsed()
        {
            return isUsed;
        }
    }
}
