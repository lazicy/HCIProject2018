using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI2018PZ4._3EURA78_2015.Validacija
{
    public class StrToDouble : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                double r;
                Console.WriteLine("ping");
                if (double.TryParse(s, out r))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Please enter a valid double value.");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }
}
