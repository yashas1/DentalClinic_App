using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DentalCareFrontend
{
    class CreditCardRule : ValidationRule
    {
        private string label;

        public string Label { get => label; set => label = value; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value.ToString();
            ValidationResult validationResult = null;
            if (input == string.Empty)
            {
                validationResult = new ValidationResult(false, $"{Label} is required");
            }
            else if (ulong.TryParse(input, out _))
            {
                validationResult = new ValidationResult(false, $"{Label} has invalid character");
            }
            else if (input.Trim().Length != 16)
            {
                validationResult = new ValidationResult(false, $"{Label} length is incorrect (16 digits)");
            } 
            else
            {
                validationResult = ValidationResult.ValidResult;
            }

            return validationResult;
        }
    }
}
