using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test.Utilities
{
    public class RegularExpression
    {
        //Method to check if string is a valid email address. Must be internal to be able to use in ContactService
        internal static bool IsValidEmail(string email)
        {
            // Regex pattern for a simple email validation
            const string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
