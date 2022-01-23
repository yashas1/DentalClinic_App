using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DentalCareFrontend
{
    class NumberRangeRule : ValidationRule
    {
        private int max;
        private int min;
        private string label;

        public int Max { get => max; set => max = value; }
        public int Min { get => min; set => min = value; }
        public string Label { get => label; set => label = value; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int number = 0;
            ValidationResult validationResult = null;
            if (value.ToString() == string.Empty)
            {
                validationResult = new ValidationResult(false, $"{label} is required");
            }
            else if (!int.TryParse((string)value, out number))
            {
                validationResult = new ValidationResult(false, "Data type is invalid");
            } 
            else if (number < min || number > max)
            {
                validationResult = new ValidationResult(false, $"{label} is out of range ({min} - {max})");
            } 
            else
            {
                validationResult = ValidationResult.ValidResult;
            }

            return validationResult;
        }
    }
}
