using System;

public class CalculatorNumber
{
    private Boolean isUsed = false;
    private long decimals = 0;
    private double num;
    private long additionalZeros;

    public CalculatorNumber()
    {

    }

    public void clear()
    {
        isUsed = false;
        decimals = 0;
        num = 0;
        additionalZeros = 0;
    }


    public string stringValue()
    {
        string outstring;

        outstring = Convert.ToString(num);
        for (int i = 0; i < additionalZeros;)
        {
            outstring = outstring + "0";
        }

        return outstring;
    }

    public void addInput(byte inp)
    {
        isUsed = true;

        if (decimals > 0)
        {
            decimals++;

            if (inp == 0)
            {
                additionalZeros++;
            }
            else
            {
                num += inp * Math.Pow(0.1, decimals);
            }
        }
        else
        {
            num = num * 10 + inp;
        }
    }

    public void addinput(double inp)
    {
        isUsed = true;
        additionalZeros = 0;
        num = inp;
        decimals = 0;
    }

}
}
