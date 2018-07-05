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
using System.Collections.Generic;

public partial class MemberProfile : System.Web.UI.Page
{
    // This creates an integer to store the Member ID.
    public int ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            // his sets the MemberID equal to the session ID.
            ID = Convert.ToInt32(Session["thisUserID"]);

        }
        catch (Exception)
        {
            // If the session ID is empty it takes you too the sign in page.
            Response.Redirect("Signin.aspx");
        }
        // This sets the HTML text equal to the First and second name equal to the logged in member.
        Name.Text = Repository.LoggedInMember.FirstName + " " + Repository.LoggedInMember.SecondName;
        // This creates a connection with the database and sets the profile picture.
        OleDbConnection conn = FilmWebsite.DB.OpenConnection();
        conn.Open();
        string SQL = "Select FilePath FROM Images WHERE MemberID = ?";
        OleDbDataAdapter da = new OleDbDataAdapter(SQL, conn);
        da.SelectCommand.Parameters.AddWithValue("MemberID", ID);
        DataTable Results = new DataTable();
        try
        {
            da.Fill(Results);
            Image1.ImageUrl = Results.Rows[0]["FilePath"].ToString();

        }
        catch
        {
            // If there is no URL in the database then the image gets set as a default image.
            Image1.ImageUrl = @"images\default-user.png";
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }

         

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        // Set the ID equal to the MumberID.
        ID = Repository.LoggedInMember.MemberID;

        if (FileUpload1.PostedFile != null)
        {
            string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

            //Save files to disk
            FileUpload1.SaveAs(Server.MapPath("images/" + FileName));

            //Add Entry to DataBase
            OleDbConnection conn = FilmWebsite.DB.OpenConnection();
            conn.Open();

            string SQL = "insert into Images (MemberID, FileName, FilePath)" +
               " values(@ID, @FileName, @FilePath)";
            OleDbCommand cmd = new OleDbCommand(SQL, conn);
            cmd.Parameters.AddWithValue("@MemberID", ID);
            cmd.Parameters.AddWithValue("@FileName", FileName);
            cmd.Parameters.AddWithValue("@FilePath", "images/" + FileName);
            string USQL = "delete from images WHERE MemberID = ?";
            OleDbCommand Ucmd = new OleDbCommand(USQL, conn);
            Ucmd.Parameters.AddWithValue("@MemberID", ID);

            cmd.CommandType = CommandType.Text;
            try
            {
                Ucmd.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                Response.Redirect(Request.RawUrl);


            }
           
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    public string FormatLink(string FirstName, string SecondName)
    {
        return FirstName + " " + SecondName;
    }
}