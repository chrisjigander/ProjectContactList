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
        myLiteral.Text = JsonConvert.SerializeObject(DataController.ReadContacts());
    }


}