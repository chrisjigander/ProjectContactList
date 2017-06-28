using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class Contact : System.Web.UI.Page
{
    static string connectionString = "Data Source=localhost;Initial Catalog=ContactDB;Integrated Security=True";

    static List<Person> contactList = new List<Person>();

    protected void Page_Load(object sender, EventArgs e)
    {
        contactList.Clear();
        GetContacts();
        myLiteral.Text = JsonConvert.SerializeObject(contactList);
    }

    public static void GetContacts()
    {

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

                contactList.Add(new Person(Id, firstName, lastName));
            }

        }
        catch (Exception ex)
        {

        }
        finally
        {
            myConnection.Close();
        }
    }
}