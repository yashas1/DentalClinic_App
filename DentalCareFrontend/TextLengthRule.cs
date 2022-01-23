using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DentalCareFrontend
{
    class TextLengthRule : ValidationRule
    {
        private int maxLength;
        private int minLength;
        private string label;

        public int MaxLength { get => maxLength; set => maxLength = value; }
        public int MinLength { get => minLength; set => minLength = value; }
        public string Label { get => label; set => label = value; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value.ToString();
            ValidationResult validationResult = null;
            if (input == string.Empty)
            {
                validationResult = new ValidationResult(false, $"{Label} is required");
            }
            else if (input.Length < minLength || input.Length > maxLength)
            {
                validationResult = new ValidationResult(false, $"{Label} length is incorrect ({minLength} - {maxLength})");
            } 
            else
            {
                validationResult = ValidationResult.ValidResult;
            }

            return validationResult;
        }
    }
}
