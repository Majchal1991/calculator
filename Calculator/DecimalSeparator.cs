using System.Globalization;

namespace Calculator
{
    public class DecimalSeparator
    {
        public static string GetDecimalSeparator()
        {
            return CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        }
    }
}
