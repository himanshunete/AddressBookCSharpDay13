using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookDay13
{
    public class ValidationCustomException : Exception
    {
        ExceptionType type;
        public enum ExceptionType
        {
            FIRST_NAME_MESSAGE,
            LAST_NAME_MESSAGE,
            ADDRESS_MESSAGE,
            ZIP_MESSAGE,
            EMAIL_MESSAGE,
            MOBILE_NUMBER_MESSAGE,




        }
        public ValidationCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }

}
