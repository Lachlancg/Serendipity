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
        try
        {
            // This creates a new Member object.
            Member NewMember = new Member();
            // This sets the information that the user has entered equal to the new member.
            NewMember.FirstName = FirstName.Text;
            NewMember.SecondName = SecondName.Text;
            // This checks if the emails are correct.
            if (Email.Text == ConfirmEmail.Text)
            {
                NewMember.Email = Email.Text;
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Email does not match" + "');", true);
            }
            // This also hashes the password.
            NewMember.Password = FilmWebsite.Repository.getMd5Hash(Password.Text);

            // This saves the member to the database.
            NewMember.save();
            // This sends you to the main page.
            FilmWebsite.Repository.LoggedInMember = FilmWebsite.Repository.checkPassword(Email.Text, FilmWebsite.Repository.getMd5Hash(Password.Text));
            if (FilmWebsite.Repository.LoggedInMember != null)
            {
                // This then creates a session variable and sets it equal to the MemberID
                Session["thisUserID"] = FilmWebsite.Repository.LoggedInMember.MemberID;
            }
                Response.Redirect("Rate5.aspx");
        }
        catch (Exception)
        {
            // If the users dont fill out the form properly then it gives them an error.
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Ensure all fields are filled out properly" + "');", true);
        }


    }

 

}