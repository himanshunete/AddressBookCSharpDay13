﻿using System;
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
        private List<ContactDetails> contactDetailsList;
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


        public void AddDetails(string addressBook, string firstName, string LastName, string address, string city, string state, int zip, int phoneNumber1, int phoneNumber2, string email)
        {
            ContactDetails contactDetails = new ContactDetails(addressBook, firstName, LastName, address, city, state, zip, phoneNumber1, phoneNumber2, email);
            var result = contactDetailsList.Where(x => x.firstName == firstName);
            //No Duplicate Entries
            if (result == null)
            {
                contactDetailsList.Add(contactDetails);
                contactDetailsMap.Add(firstName, contactDetails);
            }  

        }

        public void AddressBook(string addressBook)
        {
            multipleAddressBookMap.Add(addressBook, contactDetailsMap);
        }
       

        public void EditDetails(string addressBook, string firstName, string LastName, string address, string city, string state, int zip, int phoneNumber1, int phoneNumber2, String email)
        {
            ContactDetails contactDetails = new ContactDetails(addressBook, firstName, LastName, address, city, state, zip, phoneNumber1, phoneNumber2, email);

            int index = Convert.ToInt32(Console.ReadLine());
            contactDetailsList[index] = contactDetails;
            contactDetailsMap[firstName] = contactDetails;
        }

        public void DeleteDetails(string firstName)
        {
            int index = Convert.ToInt32(Console.ReadLine());
            contactDetailsList.RemoveAt(index);
            contactDetailsMap.Remove(firstName);
        }

        
        public void MultipleAddressBook()
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

            sportBook.AddDetails( "Sports", "Virat", " Kohli ", " ldikr lyout ", " Mumbai ", " Maharashtra ", 440024, 88059, 56103, " kohli@gmail.com ");
            sportBook.AddDetails("Sports", " MS ", " Dhoni ", " Gulmohr Chowk ", " Ranchi ", " Jharkhand ", 440011, 88011, 56102, " dhoni@gmail.com ");
            sportBook.AddDetails("Sports", "KL ", " Rahul ", " Parker Bay ", " Banglore ", " Karnataka ", 440017, 88060, 11103, " rahul@gmail.com ");
            Console.WriteLine(" Enter Book1: ");
            string addressBook = Console.ReadLine();
            sportBook.AddressBook(addressBook);
            sportBook.ComputeDetails();


            businessBook.MultipleAddressBook();
            Console.WriteLine(" Enter Book2: ");
            addressBook = Console.ReadLine();
            businessBook.AddressBook(addressBook);
            businessBook.ComputeDetails();


            Console.WriteLine(" Edit or Delete options: Enter EDIT:0 & DELETE:1 ");
            int option = Convert.ToInt32(Console.ReadLine());
            const int EDIT = 0;
            const int DELETE = 1;
            switch (option)
            {
                case EDIT:
                    int noOfEdits = Convert.ToInt32(Console.ReadLine());
                    for (int numOfPerson = 1; numOfPerson < noOfEdits; numOfPerson++)
                    {
                        addressBook = Console.ReadLine();
                        string firstName = Console.ReadLine();
                        string lastName = Console.ReadLine();
                        string address = Console.ReadLine();
                        string city = Console.ReadLine();
                        string state = Console.ReadLine();
                        int zip = Convert.ToInt32(Console.ReadLine());
                        int phoneNumber1 = Convert.ToInt32(Console.ReadLine());
                        int phoneNumber2 = Convert.ToInt32(Console.ReadLine());
                        string email = Console.ReadLine();
                        sportBook.EditDetails(addressBook, firstName, lastName, address, city, state, zip, phoneNumber1, phoneNumber2, email);
                    }
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
