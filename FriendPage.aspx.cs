using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using FilmWebsite;


public partial class FriendPage : System.Web.UI.Page
{
    // Creating a boolean which stores whether youre friends with the member.
    public static bool alreadyFriends;
    // Creating a boolean which stores whether youre friends with the member.
    public static bool IsFriends;
    // This string stores the friends ID.
    public static string StrFriend;
    protected void Page_Load(object sender, EventArgs e)
    {
        // This sets the StrFriend as the MemberID which is passed through the URL.
        StrFriend = Request.QueryString["MemberID"];
        // This creates a session variable and sets it equal to the Friends ID.
        Session["thisFriendID"] = StrFriend;
        // This checks if the string is empty and if it is then it takes you to the main pahe.
        if (StrFriend == null)
        {
            Response.Redirect("Members.aspx");
        }
        // This runs the Checkfriends method which returns a boolean value.
        IsFriends = Repository.CheckFriend(Repository.LoggedInMember.MemberID, int.Parse(StrFriend));
        // This initialies a new intance of a Member object.
        Member F = new Member();
        // This fills this object using the friends ID.
        F = Repository.BuildMember(StrFriend);

        // This sets the HTML text to the same as the friends first and second name.
        Name.Text = F.FirstName + " " + F.SecondName;
        // This creates a connection with the database and then runs an SQL query to retrieve the profile picture.
        OleDbConnection conn = FilmWebsite.DB.OpenConnection();
        conn.Open();
        string SQL = "Select FilePath FROM Images WHERE MemberID = ?";
        OleDbDataAdapter da = new OleDbDataAdapter(SQL, conn);
        da.SelectCommand.Parameters.AddWithValue("MemberID", StrFriend);
        DataTable Results = new DataTable();
        try
        {
            da.Fill(Results);
            Image1.ImageUrl = Results.Rows[0]["FilePath"].ToString();

        }
        catch (Exception)
        {
            Image1.ImageUrl = "images/default-user.png";
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        // This sets the button to add friends as visible or not, if they are friends then it shows the add freinds button.
        if (IsFriends == true)
        {
            Button1.Visible = false;
            Button2.Visible = true;

        }
        else
        {
            Button1.Visible = true;
            Button2.Visible = false;
        }
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // This initialises a new Memeber object and sets it using the the user ID.
        Member LoggedIn = new Member(Convert.ToString(Session["thisUserID"]));
        // This does the same apart from with a Friend object.
        Friend NewFriend = new Friend(LoggedIn, StrFriend);
        // This sets the boolean value to true as they are friends.
        alreadyFriends = NewFriend.save();
        // This refreshes the page.
        Response.Redirect(Request.RawUrl);
        // If the boolean value is friends it gives an error as they are friends.
        if (alreadyFriends == false)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Already Friends with this user" + "');", true);
        }
        

        
    }
    protected void Button2_Click(object sender, EventArgs e)
        {
        // This deletes the friend from the database.
        Friend NewFriend = new Friend(FilmWebsite.Repository.LoggedInMember, StrFriend);
        alreadyFriends = NewFriend.Delete();
        Response.Redirect(Request.RawUrl);
        
            

        
    }
}