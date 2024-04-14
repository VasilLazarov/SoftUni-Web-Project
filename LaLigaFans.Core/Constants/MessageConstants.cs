using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaLigaFans.Core.Constants
{
    public static class MessageConstants
    {
        public const string StringLengthErrorMessage = "The field {0} must be between {2} and {1} characters long";

        public const string NumberErrorMessage = "The field {0} must be between {1} and {2}";

        public const string PasswordLengthErrorMessage = "The {0} must be at least {2} and at max {1} characters long.";

        public const string PasswordMatchErrorMessage = "The password and confirmation password do not match.";

        public const string RequiredMessage = "The field {0} is required";
        
        public const string UploadImageErrorMessage = "You must upload an image";

        public const string TeamErrorMessage = "Team does not exists!";




    }
}
