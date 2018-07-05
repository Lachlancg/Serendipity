using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FilmWebsite;

public partial class SignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        // Sets the logged in member as the person who is logging in and checks the password.
        FilmWebsite.Repository.LoggedInMember = FilmWebsite.Repository.checkPassword(Email.Text, FilmWebsite.Repository.getMd5Hash(Password.Text));
        if (FilmWebsite.Repository.LoggedInMember != null)
        {
            // This then creates a session variable and sets it equal to the MemberID
            Session["thisUserID"] = FilmWebsite.Repository.LoggedInMember.MemberID;

            // THis then sends you to the main page.
            Response.Redirect("Members.aspx");


        }
        else
        {
            // If the password is wrong then you get an error.
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Check Username and Password" + "');", true);
        }
    }
}