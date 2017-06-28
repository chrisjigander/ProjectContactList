using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Person
{
    private int id;
    public int ID { get { return id; } }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Address Address { get; set; }
    public string PhoneNumber { get; set; }

    //public List<Address> Addresses { get; set; }

    public Person(int id, string firstName, string lastName, Address address, string phoneNumber)
    {
        this.id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        PhoneNumber = phoneNumber;
    }
}