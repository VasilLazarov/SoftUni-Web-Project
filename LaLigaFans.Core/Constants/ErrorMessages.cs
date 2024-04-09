using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaLigaFans.Core.Constants
{
    public static class ErrorMessages
    {
        public const string StringLengthErrorMessage = "{0} must be between {2} and {1} characters";

        public const string PasswordLengthErrorMessage = "The {0} must be at least {2} and at max {1} characters long.";

        public const string PasswordMatchErrorMessage = "The password and confirmation password do not match.";


    }
}
