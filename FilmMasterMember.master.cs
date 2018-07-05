using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FilmMasterMember : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["thisUserID"] == null)
        {
            Response.Redirect("SignIn.aspx");

        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.Remove("thisUserID");
        Session.RemoveAll();
        Response.Redirect("SignIn.aspx");
    }
}
