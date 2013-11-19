using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace MagicSquare
{
    class NumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string pattern = @"\A[1-9]+\Z";

            if (Regex.IsMatch((string)value, pattern))
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Value must be a number in interval [1-9]!");
            }
        }
    }
}