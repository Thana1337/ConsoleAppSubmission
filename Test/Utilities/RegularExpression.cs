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
        // Method to check if string is a valid phone number. Must be internal to be able to use in ContactService
        internal static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Regex pattern for a simple phone number validation (at least 10 digits)
            const string phonePattern = @"^\d{10,}$";
            return Regex.IsMatch(phoneNumber, phonePattern);
        }
    }
}
