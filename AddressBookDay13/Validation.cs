using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace AddressBookDay13
{

    public class Validation
    {
        string firstNamePattern = "^[A-Z]{1}[a-z]{2,}$";
        string lastNamePattern = "^[A-Z]{1}[a-z]{2,}$";
        string addressPattern = "^[A-Z]{1}[a-z]{2,}[ ][A-Z]{1}[a-z]{2,}$";
        string zipPattern = "[4]{1}[4]{1}[0]{1}[0]{1}[0-9]{2}$";
        string emailPattern = "^[0-9a-zA-Z]+([._+-]?[0-9a-zA-Z]+)*@[0-9A-Za-z]+.([c]{1}[o]{1}[m]{1})*([n]{1}[e]{1}[t]{1})*[,]*([.][a]{1}[u]{1})*([.][c]{1}[o]{1}[m]{1})*$";
        string mobileNumberPattern = "^[0-9]{10}$";



        /// <summary>
        /// FirstName Custom Exception
        /// </summary>
        /// <param name="patternFirstName"></param>
        /// <returns></returns>
        public string FirstName(string patternFirstName)
        {
            Regex regex = new Regex(firstNamePattern);
            var result = regex.Match(patternFirstName);
            try
            {

                if (!result.Success)
                {
                    throw new ValidationCustomException(ValidationCustomException.ExceptionType.FIRST_NAME_MESSAGE, "FirstName is not valid");
                }
                return "FirstName is valid";
            }
            catch
            {
                throw new ValidationCustomException(ValidationCustomException.ExceptionType.FIRST_NAME_MESSAGE, "FirstName is not valid");
            }
        }

        /// <summary>
        /// LastName Custom Exception
        /// </summary>
        /// <param name="patternLastName"></param>
        /// <returns></returns>
        public string LastName(string patternLastName)
        {
            Regex regex = new Regex(lastNamePattern);
            var result = regex.Match(patternLastName);
            try
            {


                if (!result.Success)
                {
                    throw new ValidationCustomException(ValidationCustomException.ExceptionType.LAST_NAME_MESSAGE, "LastName is not valid");
                }
                return "LastName is valid";
            }
            catch
            {
                throw new ValidationCustomException(ValidationCustomException.ExceptionType.LAST_NAME_MESSAGE, "LastName is not valid");
            }
        }

        /// <summary>
        /// Address Custom Exception
        /// </summary>
        /// <param name="patternLastName"></param>
        /// <returns></returns>
        public string Address(string patternAddress)
        {
            Regex regex = new Regex(addressPattern);
            var result = regex.Match(patternAddress);
            try
            {


                if (!result.Success)
                {
                    throw new ValidationCustomException(ValidationCustomException.ExceptionType.ADDRESS_MESSAGE, "Address is not valid");
                }
                return "Address is valid";
            }
            catch
            {
                throw new ValidationCustomException(ValidationCustomException.ExceptionType.ADDRESS_MESSAGE, "Address is not valid");
            }
        }


        /// <summary>
        /// Zip Custom Exception
        /// </summary>
        /// <param name="patternLastName"></param>
        /// <returns></returns>
        public string Zip(string patternZip)
        {
            Regex regex = new Regex(zipPattern);
            var result = regex.Match(patternZip);
            try
            {


                if (!result.Success)
                {
                    throw new ValidationCustomException(ValidationCustomException.ExceptionType.ZIP_MESSAGE, "Zip is not valid");
                }
                return "Zip is valid";
            }
            catch
            {
                throw new ValidationCustomException(ValidationCustomException.ExceptionType.ZIP_MESSAGE, "Zip is not valid");
            }
        }


        /// <summary>
        /// Email Custom Exception
        /// </summary>
        /// <param name="patternEmail"></param>
        /// <returns></returns>
        public string EmailAddress(string patternEmail)
        {
            Regex regex = new Regex(emailPattern);
            var result = regex.Match(patternEmail);
            try
            {


                if (!result.Success)
                {
                    throw new ValidationCustomException(ValidationCustomException.ExceptionType.EMAIL_MESSAGE, "Email is not valid");
                }
                return "Email is valid";
            }
            catch
            {
                throw new ValidationCustomException(ValidationCustomException.ExceptionType.EMAIL_MESSAGE, "Email is not valid");
            }
        }

        /// <summary>
        /// Mobile Number Custom Exception
        /// </summary>
        /// <param name="patternMobileNumber"></param>
        /// <returns></returns>
        public string MobileNumber(string patternMobileNumber)
        {
            Regex regex = new Regex(mobileNumberPattern);
            var result = regex.Match(patternMobileNumber);
            try
            {


                if (!result.Success)
                {
                    throw new ValidationCustomException(ValidationCustomException.ExceptionType.MOBILE_NUMBER_MESSAGE, "Mobile Number is not valid");
                }
                return "Mobile Number is valid";
            }
            catch
            {
                throw new ValidationCustomException(ValidationCustomException.ExceptionType.MOBILE_NUMBER_MESSAGE, "Mobile Number is not valid");
            }
        }

    }
}
