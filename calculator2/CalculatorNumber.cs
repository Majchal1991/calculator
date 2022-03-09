using System;

namespace Calculator
{
    public class CalculatorNumber
    {
        private const string additionalZeroChar = "0";

        private bool isUsed = false;
        private long decimalsCount = 0;
        private long additionalZerosCount = 0;
        private double number = 0;
        private string errorType = string.Empty;


        public CalculatorNumber()
        {

        }

        public void Clear()
        {
            isUsed = false;
            decimalsCount = 0;
            number = 0;
            additionalZerosCount = 0;
            errorType = string.Empty;
        }

        public void SetError(string errorType)
        {
            this.errorType = errorType;
        }

        public string GetStringValue()
        {
            string decimalSeparator = (Convert.ToString(0.1)).Substring(1, 1);
            string resultString;

            if (HasErrorValue())
            {
                return errorType;
            }

            if (isUsed == false)
            {
                return string.Empty;
            }
            else
            {
                resultString = Convert.ToString(number);

                if (decimalsCount > 0 && decimalsCount == additionalZerosCount + 1 && additionalZerosCount != 0)
                {
                    resultString += decimalSeparator;
                }

                for (int i = 0; i < additionalZerosCount; i++)
                {
                    resultString += additionalZeroChar;
                }

                return resultString;
            }
        }

        public double GetValue()
        {
            return number;
        }

        public void AddDigit(int input)
        {
            const double decimalMultiplier = 10;
            const double decimalDivider = 0.1;

            isUsed = true;

            if (decimalsCount > 0)
            {
                if (input == 0)
                {
                    additionalZerosCount++;
                }
                else
                {
                    number += input * Math.Pow(decimalDivider, decimalsCount);
                    additionalZerosCount = 0;
                }

                decimalsCount++;
            }
            else
            {
                number = number * decimalMultiplier + input;
            }
        }

        public void SetNumber(double input)
        {
            isUsed = true;
            additionalZerosCount = 0;
            number = input;
            decimalsCount = 0;
        }

        public void TurnOnDecimal()
        {
            if (decimalsCount == 0) 
            { 
                decimalsCount = 1;
            }
        }

        public bool IsUsed()
        {
            return isUsed;
        }

        public bool HasErrorValue()
        {
            return !string.IsNullOrEmpty(errorType);
        }
    }
}
