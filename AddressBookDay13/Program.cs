using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookDay13
{
    class ContactDetails
    {
        public string firstName;
        public string lastName;
        public string address;
        public string city;
        public string state;
        public int zip;
        public int phoneNumber1;
        public int phoneNumber2;
        public string email;
        public string addressBook;
      

        public ContactDetails(string addressBook, string firstName, string lastName, string address, string city, string state, int zip, int phoneNumber1, int phoneNumber2, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNumber1 = phoneNumber1;
            this.phoneNumber2 = phoneNumber2;
            this.email = email;
            this.addressBook = addressBook;
        }

    

        public string toString()
        {
            return  "Address Book: " +addressBook+ "\n"
                                   +""   +" Details of " + firstName + " " + lastName + " are: " + " Address: " + address + "  City: " + city + "\n"
                                    + "                               " + " State: " + state + "  Zip: " + zip + "\n"
                                    + "                               " + " PhoneNumber: " + phoneNumber1 + phoneNumber2 + "\n"
                                    + "                               "  + " Email: " + email;

        }
    }

    //Computation
    class Program
    {
        public List<ContactDetails> contactDetailsList;
        private Dictionary<string, ContactDetails> contactDetailsMap;
    //  private List<List<ContactDetails>> multipleAddressBookList;
        private Dictionary<string, Dictionary<string, ContactDetails>> multipleAddressBookMap;

        public Program()
        {
            contactDetailsList = new List<ContactDetails>();
            contactDetailsMap = new Dictionary<string, ContactDetails>();
    //      multipleAddressBookList = new List<List<ContactDetails>>();
            multipleAddressBookMap = new Dictionary<string, Dictionary<string, ContactDetails>>();
        }

        // Add detail logic in Book using collection
        public void AddDetails(string addressBook, string firstName, string LastName, string address, string city, string state, int zip, int phoneNumber1, int phoneNumber2, string email)
        {
            ContactDetails contactDetails = new ContactDetails(addressBook, firstName, LastName, address, city, state, zip, phoneNumber1, phoneNumber2, email);
            //No Duplicate Entries
            if (contactDetailsMap.ContainsKey(firstName) == false)
            {
                contactDetailsList.Add(contactDetails);
                contactDetailsMap.Add(firstName, contactDetails);
            }
        }

        // Create Nested Dictionary
        public void AddressBook(string addressBook)
        {
            multipleAddressBookMap.Add(addressBook, contactDetailsMap);
        }
       
        // update the elements given in the list
        public void EditDetails(string addressBook, string firstName, string LastName, string address, string city, string state, int zip, int phoneNumber1, int phoneNumber2, String email)
        {
            ContactDetails contactDetails = new ContactDetails(addressBook, firstName, LastName, address, city, state, zip, phoneNumber1, phoneNumber2, email);
            Console.WriteLine(" Select index: ");
            int index = Convert.ToInt32(Console.ReadLine());
            contactDetailsList[index] = contactDetails;
            contactDetailsMap[firstName] = contactDetails;
        }

        // delete the detail 
        public void DeleteDetails(string firstName)
        {
            Console.WriteLine("Enter index");
            int index = Convert.ToInt32(Console.ReadLine());
            contactDetailsList.RemoveAt(index);
            contactDetailsMap.Remove(firstName);
        }

        //Searching a Person
        public void Search()
        {
            Console.WriteLine(" Enter state ");
            string state = Console.ReadLine();
            var stateCheck = contactDetailsList.FindAll(x => x.state == state);
            Console.WriteLine(" Enter city ");
            string city = Console.ReadLine();
            var cityCheck = stateCheck.FindAll(x => x.city == city);
            Console.WriteLine(" Find Person ");
            string firstName = Console.ReadLine();
            var person = cityCheck.Where(x => x.firstName == firstName).FirstOrDefault();
            if (person != null)
            {
                Console.WriteLine( firstName +" is  in " + city);
            }
            else
            {
                Console.WriteLine(firstName + " is not  in " + city);
            }

            Dictionary<string, ContactDetails> detailCity = new Dictionary<string, ContactDetails>();
            Dictionary<string, ContactDetails> detailState = new Dictionary<string, ContactDetails>();
            detailCity.Add(city, person);
            detailState.Add(state, person);
            foreach(KeyValuePair<string, ContactDetails> i in detailCity)
            {
                Console.WriteLine("City: {0}  {1}", i.Key, i.Value.toString());
            }

            foreach (KeyValuePair<string, ContactDetails> i in detailState)
            {
                Console.WriteLine("State: {0}  {1}", i.Key, i.Value.toString());
            }

        }

        //User Input for adding the details in a book
        public void UserInputDetails()
        {
            Console.WriteLine(" Total number of persons we wanna add : ");
            int noOfPersons = Convert.ToInt32(Console.ReadLine());
            //AddressBook
            for (int numOfPerson = 1; numOfPerson < noOfPersons; numOfPerson++)
            {
                string addressBook = Console.ReadLine();
                string firstName = Console.ReadLine();
                string lastName = Console.ReadLine();
                string address = Console.ReadLine();
                string city = Console.ReadLine();
                string state = Console.ReadLine();
                int zip = Convert.ToInt32(Console.ReadLine());
                int phoneNumber1 = Convert.ToInt32(Console.ReadLine());
                int phoneNumber2 = Convert.ToInt32(Console.ReadLine());
                string email = Console.ReadLine();
                AddDetails(addressBook, firstName, lastName, address, city, state, zip, phoneNumber1, phoneNumber2, email);
            }
        }

        //User input for editing the details for a book
        public void UserInputEditDetails()
        {
            Console.WriteLine(" No. of Edits: ");
            int noOfEdits = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < noOfEdits; i++)
            {
                Console.WriteLine(" Enter details");
//              var result = contactDetailsList.Select(x => x.city.Replace()).ToList();
                string addressBook = Console.ReadLine();
                string firstName = Console.ReadLine();
                string lastName = Console.ReadLine();
                string address = Console.ReadLine();
                string city = Console.ReadLine();
                string state = Console.ReadLine();
                int zip = Convert.ToInt32(Console.ReadLine());
                int phoneNumber1 = Convert.ToInt32(Console.ReadLine());
                int phoneNumber2 = Convert.ToInt32(Console.ReadLine());
                string email = Console.ReadLine();
                EditDetails(addressBook, firstName, lastName, address, city, state, zip, phoneNumber1, phoneNumber2, email);
            }
        }

        //Display the information
        public void ComputeDetails()
        {
            // foreach (KeyValuePair<string, Dictionary<string, ContactDetails>> book in multipleAddressBookMap)
            // {
            //     Console.WriteLine("Key: {0}, Value: {1}", book.Key, book.Value);
            // }
            //Console.WriteLine(multipleAddressBookMap.ToString());


            foreach(ContactDetails book in contactDetailsList)
            { 
                Console.WriteLine(book.toString());
            }
            //    (int x = 0; x < multipleAddressBookMap.Count; x++)
            //    {
            //        Console.WriteLine("{0} n {1}", multipleAddressBookMap.Keys.ElementAt(x), multipleAddressBookMap.Values.ElementAt(x));
            //    }


            //    for (int i1 = 0; i1 < multipleAddressBookList.Count; i1++)
            //    {
            //       Console.WriteLine(multipleAddressBookList[i1]);
            //   }
            //     
            Console.WriteLine("**********************************");
            Console.WriteLine(" Dictionary of Address Book ");
               foreach (var k in multipleAddressBookMap)
               {
                   foreach (var innerk in k.Value)
                   {
                       Console.WriteLine("Address Book: {0} ,FirstName: {1}, {2}", k.Key, innerk.Key, innerk.Value.toString());
                   }
               }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(" Welcome to Address Book System ");
            Program sportBook = new Program();
            Program businessBook = new Program();

            //AddressBook1
            sportBook.AddDetails( "Sports", "Virat", " Kohli ", " ldikr lyout ", "Mumbai", "Maharashtra", 440024, 88059, 56103, " kohli@gmail.com ");
            sportBook.AddDetails("Sports", "MS", " Dhoni ", " Gulmohr Chowk ", "Pune", "Maharashtra", 440011, 88011, 56102, " dhoni@gmail.com ");
            sportBook.AddDetails("Sports", "KL", " Rahul ", " Parker Bay ", "Banglore", "Karnataka", 440017, 88060, 11103, " rahul@gmail.com ");
            sportBook.AddDetails("Sports", "Sachin", " Tendulkar ", " Parker Bay ", "Mumbai", "Maharashtra", 440017, 88060, 11103, " rahul@gmail.com ");
            sportBook.AddDetails("Sports", "Ajinkya", " Rahane ", " Parker Bay ", "Mumbai", "Maharashtra", 440017, 88060, 11103, " rahul@gmail.com ");
            Console.WriteLine(" Enter Book1: ");
            string addressBook = Console.ReadLine();
            sportBook.AddressBook(addressBook);
            sportBook.ComputeDetails();
            sportBook.Search();

            //AddressBook2
            businessBook.UserInputDetails();
            Console.WriteLine(" Enter Book2: ");
            addressBook = Console.ReadLine();
            businessBook.AddressBook(addressBook);
            businessBook.ComputeDetails();
            businessBook.Search();

            //Manipulation
            Console.WriteLine(" Wanna manipulate or not ? YES or NO ");
            string answer = Console.ReadLine();
            if ("YES" == answer)
            {
                Console.WriteLine(" Edit or Delete options: Enter EDIT:0 & DELETE:1 ");
                int option = Convert.ToInt32(Console.ReadLine());
                const int EDIT = 0;
                const int DELETE = 1;
                switch (option)
                {
                    case EDIT:
                        sportBook.UserInputEditDetails();
                        sportBook.ComputeDetails();
                        break;
                    case DELETE:
                        int noOfDeletes = Convert.ToInt32(Console.ReadLine());
                        for (int numOfPerson = 1; numOfPerson < noOfDeletes; numOfPerson++)
                        {
                            string firstName = Console.ReadLine();
                            sportBook.DeleteDetails(firstName);
                        }
                        sportBook.ComputeDetails();
                        break;
                }
            }


        }

    }
}
