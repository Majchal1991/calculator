using System;

namespace Calculator
{
    public class CalculatorNumber
    {
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
                    resultString += DecimalSeparator.GetDecimalSeparator();
                }

                for (int i = 0; i < additionalZerosCount; i++)
                {
                    resultString += 0;
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
            isUsed = true;

            if (decimalsCount > 0)
            {
                if (input == 0)
                {
                    additionalZerosCount++;
                }
                else
                {
                    number += input * Math.Pow(CalculatorNumberConstants.decimalDivider, decimalsCount);
                    additionalZerosCount = 0;
                }

                decimalsCount++;
            }
            else
            {
                number = number * CalculatorNumberConstants.decimalMultiplier + input;
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
