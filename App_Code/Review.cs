using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using FilmWebsite;

/// <summary>
/// Summary description for Review
/// </summary>
public class Review
{
    // This class builds a Review object, which creates an object with all of the data of each Review when run.
    // The following instantiates the variables used within the object.
    public Member Reviewer;

    public Film FilmReview;

    private string _rating;

    public string Rating
    {
        get { return _rating; }
        set { _rating = value; }
    }

    private string _comment;

    public string Comment
    {
        get { return _comment; }
        set { _comment = value; }
    }

    private DateTime _dateOfReview;

    public DateTime DateOfReview
    {
        get { return _dateOfReview; }
        set { _dateOfReview = value; }
    }


    public Review(DataRow DR)
    {
        // This creates a Member object when the method is passed a datarow.
        _rating = DR["Rating"].ToString();
        _comment = DR["Comment"].ToString();
        _dateOfReview = DateTime.Parse(DR["DateOfReview"].ToString()).Date;

    }

    public Review(Member M, Film F, string R, string C)
    {
        // This creates a review object from variables passed to the method.
        Reviewer = M;
        FilmReview = F;
        Rating = R;
        Comment = C;
        _dateOfReview = DateTime.Today.Date;

    }

    public bool save()
    {
        // This method saves the Review object into the database.
        // This creates a connection with the database and then runs an SQL query to fill the table.
        OleDbConnection conn = FilmWebsite.DB.OpenConnection();
        conn.Open();


        string isql = "INSERT INTO Ratings (MemberID, MovieID, Rating, Comment, DateOfReview) VALUES (?,?,?,?,?)";
        OleDbCommand Cmd = new OleDbCommand(isql, conn);
        Cmd.Parameters.AddWithValue("MemberID", Reviewer.MemberID);
        Cmd.Parameters.AddWithValue("MovieID", FilmReview.MovieID);
        Cmd.Parameters.AddWithValue("Rating", _rating);
        Cmd.Parameters.AddWithValue("Comment", _comment);
        Cmd.Parameters.AddWithValue("DateOfReview", _dateOfReview);
        try
        {
            Cmd.ExecuteNonQuery();

            Cmd.CommandText = "SELECT @@Identity";
            Reviewer.MemberID = (int)Cmd.ExecuteScalar();
            conn.Close();
            return true;
        }
        catch (Exception)
        {
            conn.Close();
            return false;

        }

    }
}