using NUnit.Framework;
using AddressBookDay13;
using System.Collections.Generic;


namespace NUnitTestProject
{
    public class Tests
    {
        Validation validation;
        Program program;
        List<ContactDetails> list = new List<ContactDetails>();
        private string addressBook;
        private string firstName;
        private string lastName;
        private string address;
        private string city;
        private string state;
        private int zip;
        private long phoneNumber;
        private string email;

        [SetUp]
        public void Setup()
        {
            validation = new Validation();
            program = new Program();
        }

        public void AddressBook()
        {
            list.Add(new ContactDetails(addressBook, firstName, lastName, address, city, state, zip, phoneNumber, email ) { firstName = "Himanshu", lastName = "Nete", address = "Ladikar Layout", city = "Nagpur", state = "Maharashtra", zip = 440024, phoneNumber = 8805956103, email = "himanshuneteh@gmail.com" });
            list.Add(new ContactDetails(addressBook, firstName, lastName, address, city, state, zip, phoneNumber, email) { firstName = "Vineet", lastName = "Kadwe", address = "Ladikar Layout", city = "Nagpur", state = "Maharashtra", zip = 440024, phoneNumber = 8805956103, email = "himanshuneteh@gmail.com" });
        }

        /// <summary>
        /// TC-1 Throw Custom Exception for Invalid FirstName
        /// </summary>
        
        [TestCase("Himanshu")]
        [TestCase("Vineet")]
        public void Given_FirstName_Expecting_ThrowCustomException(string patternFirstName)
        {
            string actual = " ";
            try
            {
                actual = validation.FirstName(patternFirstName);
            }
            catch (ValidationCustomException exception)
            {
                Assert.AreEqual("FirstName is not valid", exception.Message);
            }
        }

        /// <summary>
        /// TC-2 Throw Custom Exception for Invalid LastName
        /// </summary>
        [TestCase("Nete")]
        [TestCase("Kadwe")]
        public void Given_LastName_Expecting_ThrowCustomException(string patternLastName)
        {
            string actual = " ";
            try
            {
                actual = validation.LastName(patternLastName);
            }
            catch (ValidationCustomException exception)
            {
                Assert.AreEqual("LastName is not valid", exception.Message);
            }
        }

        /// <summary>
        /// TC-3 Throw Custom Exception for Invalid Address
        /// </summary>
        [TestCase("Ladikar Layout")]
        [TestCase("Naik Nagar")]
        public void Given_Address_Expecting_ThrowCustomException(string patternAddress)
        {
            string actual = " ";
            try
            {
                actual = validation.LastName(patternAddress);
            }
            catch (ValidationCustomException exception)
            {
                Assert.AreEqual("LastName is not valid", exception.Message);
            }
        }

        /// <summary>
        /// TC-4 Throw Custom Exception for Zip
        /// </summary>
        [TestCase("440024")]
        [TestCase("440012")]
        public void Given_Zip_Expecting_ThrowCustomException(string patternZip)
        {
            string actual = " ";
            try
            {
                actual = validation.LastName(patternZip);
            }
            catch (ValidationCustomException exception)
            {
                Assert.AreEqual("Zip is not valid", exception.Message);
            }
        }

        /// <summary>
        /// TC-5 Throw Custom Exception for Invalid Mobile Number
        /// </summary>
        [TestCase("8805956103")]
        [TestCase("8802386354")]
        public void Given_MobileNumber_Expecting_ThrowCustomException(string patternMobileNumber)
        {
            string actual = " ";
            try
            {
                actual = validation.MobileNumber(patternMobileNumber);
            }
            catch (ValidationCustomException exception)
            {
                Assert.AreEqual("Mobile Number is not valid", exception.Message);
            }
        }


        /// <summary>
        /// TC-6 Throw Custom Exception for Invalid Email
        /// </summary>
        [TestCase("himanshuneteh@gmail.com")]
        [TestCase("kadwe@gmail.com")]
        public void Given_Email_Expecting_ThrowCustomException(string sampleEmail)
        {

            string actual = " ";
            try
            {
                actual = validation.EmailAddress(sampleEmail);
            }
            catch (ValidationCustomException exception)
            {
                Assert.AreEqual("Email is not valid", exception.Message);
            }
        }

        /// <summary>
        /// TC-7 Test AddressBook 
        /// </summary>
        
        [TestCase("Sports", "Virat", " Kohli ", " ldikr lyout ", "Mumbai", "Maharashtra", 440024, 8805956103, " kohli@gmail.com ")]
        [TestCase("Sports", "MS", " Dhoni ", " Gulmohr Chowk ", "Pune", "Maharashtra", 440011, 8801156102, " dhoni@gmail.com ")]
        public void Given_List_Expecting_ReturnResult(string addressBook, string firstName, string lastName, string address, string city, string state, int zip, int phoneNumber, string email)
        {
            List<ContactDetails> actual = program.AddDetails(addressBook, firstName, lastName, address, city, state, zip, phoneNumber, email); 
            Assert.AreEqual(list, actual);
            
        }





    }





}