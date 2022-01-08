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
        private Boolean isListExpandRequired = true;
        private Double decimals = 0;
        List<String> Values = new List<String>();
        List<string> operators = new List<string>();



        public Form1()
        {
            InitializeComponent();
        }

        private void printInputs()
        {
            tb_ans.Clear();
            tb_inp.Clear();

            for (int i = 0; i < Values.Count; i++)
            {
                tb_inp.Text += Values[i];

                if (i < operators.Count)
                {
                    tb_inp.Text += operators[i];
                }
            }

        }

        private void solve()
        {
            double tempValue1;
            double tempValue2;
            string tempOperator;

            if (Values.Count > 0)
            {
                tempValue1 = Convert.ToDouble(Values[0]);

                for (int i = 1; i <= Values.Count-1; i++)
                {
                    tempValue2 = Convert.ToDouble(Values[i]);
                    tempOperator = operators[i - 1];

                    switch (tempOperator)
                    {
                        case "/":
                            tempValue1 = tempValue1 / tempValue2;
                            break;
                        case "*":
                            tempValue1 = tempValue1 * tempValue2;
                            break;
                        case "+":
                            tempValue1 = tempValue1 + tempValue2;
                            break;
                        case "-":
                            tempValue1 = tempValue1 - tempValue2;
                            break;
                    }
                }

                tb_ans.Clear();
                tb_ans.Text = Convert.ToString(tempValue1);
            }
            
        }

        private void addInput(string inp1)
        {

            switch (inp1)
            {
                case "*":
                case "/":
                case "-":
                case "+":
                    if (tb_ans.Text != "")
                    {
                        operators.Clear();
                        operators.Add(inp1); 
                        Values.Clear();
                        Values.Add(tb_ans.Text);
                        isListExpandRequired = true;
                        decimals = 0;
                    }
                    else if (operators.Count<Values.Count)
                    {
                        operators.Add(inp1);
                        decimals = 0;
                        isListExpandRequired = true;
                    }
                    break; 
 
            }

            printInputs();
        }

        private void addInput(double inp1)
        {
            double tempDouble;
            string comma = ",";

            if (inp1>=0 && inp1<=9)
            {
                if (isListExpandRequired)
                {
                    //Numbers.Add(inp1);
                    Values.Add(Convert.ToString(inp1));
                    isListExpandRequired = false;
                }
                else
                {
                    if (decimals > 0)
                    {
                        //Numbers[Numbers.Count-1] += inp1 * Math.Pow(0.1, decimals);

                        if (inp1==0 && decimals == 1)
                        {
                            Values[Values.Count - 1] += comma + "0";
                        }
                        else if(inp1 == 0 && decimals > 1 && decimals<13)
                        {
                            Values[Values.Count - 1] += "0";
                        }
                        else if (inp1 != 0)
                        {
                            tempDouble = Convert.ToDouble(Values[Values.Count - 1]);
                            tempDouble += inp1 * Math.Pow(0.1, decimals);
                            Values[Values.Count - 1] = Convert.ToString(tempDouble);
                        }

                        decimals++;
                    }
                    else
                    {
                        //Numbers[Numbers.Count-1] *= 10;
                        //Numbers[Numbers.Count-1] += inp1;

                        tempDouble = Convert.ToDouble (Values[Values.Count-1]);
                        tempDouble *= 10;
                        tempDouble += inp1;
                        (Values[Values.Count - 1]) = Convert.ToString(tempDouble);
                    }
                }
            }

            printInputs();
        }

        private void btn_C_Click(object sender, EventArgs e)
        {
            tb_ans.Clear();
            tb_inp.Clear();

            //Numbers.Clear();
            operators.Clear();
            Values.Clear();
            isListExpandRequired = true;
            decimals = 0;


    }

        private void btn_0_Click(object sender, EventArgs e) => addInput(0);
        private void btn_1_Click(object sender, EventArgs e) => addInput(1);
        private void btn_2_Click(object sender, EventArgs e) => addInput(2);
        private void btn_3_Click(object sender, EventArgs e) => addInput(3);
        private void btn_4_Click(object sender, EventArgs e) => addInput(4);
        private void btn_5_Click(object sender, EventArgs e) => addInput(5);
        private void btn_6_Click(object sender, EventArgs e) => addInput(6);
        private void btn_7_Click(object sender, EventArgs e) => addInput(7);
        private void btn_8_Click(object sender, EventArgs e) => addInput(8);
        private void btn_9_Click(object sender, EventArgs e) => addInput(9);

        private void btn_Div_Click(object sender, EventArgs e) => addInput("/");
        private void btn_Add_Click(object sender, EventArgs e) => addInput("+");
        private void btn_Min_Click(object sender, EventArgs e) => addInput("-");
        private void btn_Mul_Click(object sender, EventArgs e) => addInput("*");

        private void btn_Dot_Click(object sender, EventArgs e)
        {
            if (decimals == 0 && Values.Count >0) { decimals = 1; }
        }


        private void btn_Ans_Click(object sender, EventArgs e) => solve();

        

    }
}
