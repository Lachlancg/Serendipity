using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Net;
using System.Web.Script.Serialization;
using System.Data.OleDb;
using FilmWebsite;
/// <summary>
/// Summary description for Film
/// </summary>
public class Film
{
    // This class builds a Film object, which creates an object with all of the data of each film when run.
    // The following instantiates the variables used within the object.
    private int _movieID;

    public int MovieID
    {
        get { return _movieID; }
        set { _movieID = value; }
    }

    private string _title;

    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }

    private int _release;

    public int Release
    {
        get { return _release; }
        set { _release = value; }
    }

    private double _iMDB;

    public double IMDB
    {
        get { return _iMDB; }
        set { _iMDB = value; }
    }

    private string _cast;

    public string Cast
    {
        get { return _cast; }
        set { _cast = value; }
    }

    private string _director;

    public string Director
    {
        get { return _director; }
        set { _director = value; }
    }

    private string _genre;

    public string Genre
    {
        get { return _genre; }
        set { _genre = value; }
    }

    private string _imageURL;

    public string ImageURL
    {
        get { return _imageURL; }
        set { _imageURL = value; }
    }
    public static string GetPosterURL(string Title)
    {
        // This Method retrieves the URL for each film when the object is created.
        // This string stores the PosterURL when it is retrieved.
        string PosterURL = "";
        // This string contains the beginning of the API call and then the name of the Film is added to the end to complete it.
        string url = "http://www.omdbapi.com/?t=" + Title.Trim();

        using (WebClient wc = new WebClient())
        {
            var json = wc.DownloadString(url);
            // This Initializes a new instance of the JavaScriptSerializer class that has no type resolver.
            JavaScriptSerializer oJS = new JavaScriptSerializer();
            // This Initializes a new instance of the ImdbEntity class.
            ImdbEntity obj = new ImdbEntity();
            obj = oJS.Deserialize<ImdbEntity>(json);
            if (obj.Response != null)
            {
                PosterURL = obj.Poster;

            }


        }
        return PosterURL;

    }

    public Film(DataRow DR)
    {
        // Sets the variables equal to the variables in the DataRow.
        _movieID = int.Parse(DR["MovieID"].ToString());
        _title = DR["Title"].ToString();
        _release = int.Parse(DR["Release"].ToString());
        // If the IMDB entry in the table is null then it gets set to 0.
        if (!DBNull.Value.Equals(DR["IMDB"]))
        {
            IMDB = 0;
        }
        else
        {
            try
            {
                // Otherwise the IMDB variable gets set to the IMDB in the DataRow.
                _iMDB = double.Parse(DR["IMDB"].ToString());
            }
            catch (Exception)
            {

                IMDB = 0;
            }

        }

        _cast = DR[4].ToString();
        Director = DR["Director"].ToString();
        _genre = DR["Genre"].ToString();
    }

    public Film()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}