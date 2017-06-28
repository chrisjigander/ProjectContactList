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


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.Request["action"] != null)
        {
            if (Page.Request["action"] == "create")
            {
                string firstName = Page.Request["firstName"];
                string lastName = Page.Request["lastName"];
                string street = Page.Request["street"];
                string city = Page.Request["city"];
                string phoneNumber = Page.Request["phoneNumber"];

                DataController.CreateContact(firstName, lastName, new Address(street, city), phoneNumber);
            }
        }

        myLiteral.Text = JsonConvert.SerializeObject(DataController.ReadContacts());
    }


}