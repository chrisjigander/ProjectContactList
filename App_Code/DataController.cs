using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;

/// <summary>
/// Summary description for DataController
/// </summary>
public class DataController
{
    static string connectionString = "Data Source=localhost;Initial Catalog=ContactDB;Integrated Security=True";

    public static List<Person> contactList = new List<Person>();

    // CREATE
    public static void CreateContact(string firstName, string lastName, Address address, string phoneNumber)
    {
        SqlConnection myConnection = new SqlConnection();

        myConnection.ConnectionString = connectionString;

        try
        {
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand();

            myCommand.Connection = myConnection;

            myCommand.CommandText = "insert into Contacts (Firstname, Lastname, Street, City, Phonenumber) values ('" + firstName +"', '" + lastName +"', '" + address.Street +"', '" + address.City +"', '" + phoneNumber +"')";

            int rows = myCommand.ExecuteNonQuery();


        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
        finally
        {
            myConnection.Close();
        }
    }

    // READ
    public static List<Person> ReadContacts()
    {

        contactList.Clear();

        SqlConnection myConnection = new SqlConnection();

        myConnection.ConnectionString = connectionString;

        try
        {
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand();

            myCommand.Connection = myConnection;

            myCommand.CommandText = "select * from Contacts";

            SqlDataReader myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                int Id = Convert.ToInt32(myReader["ID"].ToString());
                string firstName = myReader["Firstname"].ToString();
                string lastName = myReader["Lastname"].ToString();
                string phoneNumber = myReader["Phonenumber"].ToString();

                Address a = new Address(myReader["Street"].ToString(), myReader["City"].ToString());

                contactList.Add(new Person(Id, firstName, lastName, a, phoneNumber));
            }

        }
        catch
        {

        }
        finally
        {
            myConnection.Close();
        }

        return contactList;
    }


    // UPDATE
    public static void UpdateContact(int id, string firstName, string lastName, Address address, string phoneNumber)
    {

    }

    // DELETE
    public static void DeleteContact(int id)
    {

    }
}