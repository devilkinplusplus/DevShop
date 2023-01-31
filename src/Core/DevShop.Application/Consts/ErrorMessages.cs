using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Consts
{
    public static class ErrorMessages
    {
        public static string NotNullException = "Cannot be empty";
        public static string OutOfRangeException = "Value is out of range";
        public static string FirstNameOutOfRangeException = "Firstname is out of range";
        public static string LastNameOutOfRangeException = "Lastname is out of range";
        public static string UserNameOutOfRangeException = "Username is out of range";
        public static string InvalidMailException = "Email address is invalid";
        public static string MinimumValueException = "Minimum value must be greater than 0.";
        
    }
}
