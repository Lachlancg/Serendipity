using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using FilmWebsite;

/// <summary>
/// Summary description for Ratings
/// </summary>
public class MemberRating
{
    // This class builds a MemberRating object, which creates an object with all of the data of each MemberRating when run.
    // The following instantiates the variables used within the object.
    private int _MemberID;

    public int MemberID
    {
        get { return _MemberID; }
        set { _MemberID = value; }
    }
    private int _CommonCount;

    public int CommonCount
    {
        get { return _CommonCount; }
        set { _CommonCount = value; }
    }
    public List<Film> _FilmsRated5 = new List<Film>();

    public MemberRating(int MemberID)
    {
        // Sets the variables equal to the results from the database when it runs an SQL query using the MemberID and movie ID.
        _CommonCount = 0;
        _MemberID = MemberID;
        OleDbConnection conn = FilmWebsite.DB.OpenConnection();
        conn.Open();

        string SQL = "Select Movies.MovieID, Movies.Title, Movies.Release, Movies.IMDB, [Movies.Cast], Movies.Director, Movies.Genre, Ratings.Rating FROM Ratings,Movies WHERE MemberID = ? AND Movies.MovieID =  Ratings.MovieID";
        OleDbDataAdapter da = new OleDbDataAdapter(SQL, conn);
        da.SelectCommand.Parameters.AddWithValue("MemberID", _MemberID);
        DataTable Results = new DataTable();
        da.Fill(Results);
        foreach (DataRow R in Results.Rows)
        {
            Film F = new Film(R);
            if (R["Rating"].ToString() == "5")
            {
                _FilmsRated5.Add(F);
            }

        }

    }
}