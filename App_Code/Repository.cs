using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Web.Script.Serialization;
using System.Net;
using System.Security.Cryptography;
using System.Text;


namespace FilmWebsite
{

    public class Repository
    {

        // This Initializes a new instance of the MemberRating class.
        public static List<MemberRating> MemberRatings = new List<MemberRating>();
        // This creates a new Member object to store the logged in members details.
        public static Member LoggedInMember;
        // This initialises a new string for the plot description
        public static string Plot;
        // This initialises a new string which will contain the poster URL.
        public static string PosterURL;

        public static List<MemberRating> BuildMemberRating()
        {
            // The method builds the rating when the user reviews a film.
            // This Initializes a new instance of the MemberRating class that is returned when the method is called.
            List<MemberRating> ReturnMemberRatings = new List<MemberRating>();
            // This Initializes a new instance of the OleDbConnection object and sets it equal to my method in the DB class.
            OleDbConnection conn = FilmWebsite.DB.OpenConnection();
            // This opens the connection.
            conn.Open();
            // This creates a string which contains the SQL to run.
            string SQL = "Select * FROM Members";
            // This initialises a new OleDbDataAdapter which uses the SQL and Connection made previously.
            OleDbDataAdapter da = new OleDbDataAdapter(SQL, conn);
            // This generates a DataTable called Results used to store the results of the SQL query.
            DataTable Results = new DataTable();
            // This fills the DataTable with the results.
            da.Fill(Results);
            // This passes the DataTable one row at a time to the  MemberRating class.
            foreach (DataRow R in Results.Rows)
            {
                // This sets the MemberID of the MemberRating Object equal to the users MemberID.
                MemberRating MR = new MemberRating(int.Parse(R["MemberID"].ToString()));
                // This adds the DataTable to the object ReturnMemberRatings.
                ReturnMemberRatings.Add(MR);
            }
            // This returns the MemberRating.
            return ReturnMemberRatings;

        }
        public static Member checkPassword(string userid, string password)
        {
            // This method checks the password when the user tries to sign in to the website.
            // This Initializes a new instance of the OleDbConnection object and sets it equal to my method in the DB class.
            OleDbConnection conn = FilmWebsite.DB.OpenConnection();
            // This opens the connection.
            conn.Open();
            // This creates a string which contains the SQL to run.
            string SQL = "Select * FROM Members WHERE Pass = ? AND Email = ?";
            // This initialises a new OleDbDataAdapter which uses the SQL and Connection made previously.
            OleDbDataAdapter da = new OleDbDataAdapter(SQL, conn);
            // This sets the value to be added to the SQL query for the Password.
            da.SelectCommand.Parameters.AddWithValue("Pass", password);
            // This sets the value to be added to the SQL query for the Email.
            da.SelectCommand.Parameters.AddWithValue("Email", userid);
            // This generates a DataTable called Results used to store the results of the SQL query.
            DataTable Results = new DataTable();
            // This fills the DataTable with the results.
            da.Fill(Results);
            // This IF statement checks if the SQL query returns a value then the code inside is run.
            conn.Close();
            if (Results.Rows.Count == 1)
            {
                // This Initializes a new instance of the Member class, this contains all of their Info.
                Member newmember = new Member(Results.Rows[0]);
                // This closes the connection.
                conn.Close();
                // This returns the Member Object.
                return newmember;
            }
            // If it doesnt return a value then the method return null.
            else
            {
                // This closes the connection.
                conn.Close();
                // This returns null.
                return null;
            }

        }

        public static bool CheckFriend(int LoggedInMember, int StrFriend)
        {
            // This method checks whether the person is your friend when you go on there profile.
            // This Initializes a new instance of the OleDbConnection object and sets it equal to my method in the DB class.
            OleDbConnection conn = FilmWebsite.DB.OpenConnection();
            // This opens the connection.
            conn.Open();
            // This creates a string which contains the SQL to run.
            string SQL = "Select Friends.IsFriend FROM Friends WHERE MemberID = ? AND FriendID = ?";
            // This initialises a new OleDbDataAdapter which uses the SQL and Connection made previously.
            OleDbDataAdapter da = new OleDbDataAdapter(SQL, conn);
            // This sets the value to be added to the SQL query for the MemberID.
            da.SelectCommand.Parameters.AddWithValue("MemberID", LoggedInMember);
            // This sets the value to be added to the SQL query for the FriendID.
            da.SelectCommand.Parameters.AddWithValue("FriendID", StrFriend);
            // This generates a DataTable called Results used to store the results of the SQL query.
            DataTable Results = new DataTable();
            // This fills the DataTable with the results.
            da.Fill(Results);
            // This IF statement checks if the SQL query returns a value then the code inside is run.
            if (Results.Rows.Count == 1)
            {
                // This returns true.
                return true;
            }
            else
            {
                // This returns false.
                return false;
            }
        }
        public static Member BuildMember(string MemberID)
        {
            // This builds a Member when the method is called.
            // This Initializes a new instance of the OleDbConnection object and sets it equal to my method in the DB class.
            OleDbConnection conn = FilmWebsite.DB.OpenConnection();
            // This opens the connection.
            conn.Open();
            // This creates a string which contains the SQL to run.
            string SQL = "Select * FROM Members WHERE MemberID = ?";
            // This initialises a new OleDbDataAdapter which uses the SQL and Connection made previously.
            OleDbDataAdapter da = new OleDbDataAdapter(SQL, conn);
            // This sets the value to be added to the SQL query for the MemberID.
            da.SelectCommand.Parameters.AddWithValue("MemberID", MemberID);
            // This generates a DataTable called Results used to store the results of the SQL query.
            DataTable Results = new DataTable();
            // This fills the DataTable with the results.
            da.Fill(Results);
            // This IF statement checks if the SQL query returns a value then the code inside is run.
            conn.Close();
            if (Results.Rows.Count == 1)
            {
                // This initialises a new Member class and fills it with the results.
                Member newmember = new Member(Results.Rows[0]);
                // This closes the connection
                conn.Close();
                // This returns when the method is called.
                return newmember;

            }
            // If there is no response from SQL this is run.
            else
            {
                //This closes the connection.
                conn.Close();
                // This returns null.
                return null;
            }
        }




        public static List<Film> SearchResults(string SearchString)
        {
            // This method searchs the DataBase for films.
            List<Film> FilmResults = new List<Film>();

            // This Initializes a new instance of the OleDbConnection object and sets it equal to my method in the DB class.
            OleDbConnection conn = FilmWebsite.DB.OpenConnection();
            // This opens a connection to the database.
            conn.Open();
            // If the 
            //if (SearchString != null)
            //{
            // This creates a string which contains the SQL to run.
            string SQL = "Select * FROM Movies WHERE Title LIKE ?";
            // This initialises a new OleDbDataAdapter which uses the SQL and Connection made previously.
            OleDbDataAdapter da = new OleDbDataAdapter(SQL, conn);
            // This sets the value to be added to the SQL query for the Search String.
            da.SelectCommand.Parameters.AddWithValue("Title", "%" + SearchString + "%");
            // This generates a DataTable called Results used to store the results of the SQL query.
            DataTable Results = new DataTable();
            // This fills the DataTable with the results.
            da.Fill(Results);
            // This passes the DataTable one row at a time to the  MemberRating class.
            foreach (DataRow R in Results.Rows)
            {
                // This initialises a new Film object and passes the datarow one line at a time.
                Film F = new Film(R);
                // This adds the Film object to the list which is returned when the method is called.
                FilmResults.Add(F);
            }
            return FilmResults;

        }
        public static List<Member> SearchResultsFriends(string SearchString)
        {
            // This method searches the database for friends.
            // This intialises a list of Friends.
            List<Member> FriendResults = new List<Member>();
            // This Initializes a new instance of the OleDbConnection object and sets it equal to my method in the DB class.
            OleDbConnection conn = FilmWebsite.DB.OpenConnection();
            // This opens a connection to the database.
            conn.Open();
            // This creates a string which contains the SQL to run.
            string SQL = "Select * FROM Members WHERE FirstName LIKE ?";
            // This initialises a new OleDbDataAdapter which uses the SQL and Connection made previously.
            OleDbDataAdapter da = new OleDbDataAdapter(SQL, conn);
            // This sets the value to be added to the SQL query for the Search String.
            da.SelectCommand.Parameters.AddWithValue("FirstName", "%" + SearchString + "%");
            // This generates a DataTable called Results used to store the results of the SQL query.
            DataTable Results = new DataTable();
            // This fills the DataTable with the results.
            da.Fill(Results);
            // This passes the DataTable one row at a time to the  MemberRating class.
            foreach (DataRow R in Results.Rows)
            {
                // This initialises a new Member object and passes the datarow one line at a time.
                Member M = new Member(R);
                // This adds the Member object to the list which is returned when the method is called.
                FriendResults.Add(M);
            }
            return FriendResults;

        }
        public static Film SearchFilm(int FilmID)
        {
            // This method searches the database for films using their ID number.
            // This Initializes a new instance of the OleDbConnection object and sets it equal to my method in the DB class.
            OleDbConnection conn = FilmWebsite.DB.OpenConnection();
            // This opens a connection to the database.
            conn.Open();
            // This creates a string which contains the SQL to run.
            string SQL = "Select * FROM Movies WHERE MovieID = ?";
            // This initialises a new OleDbDataAdapter which uses the SQL and Connection made previously.
            OleDbDataAdapter da = new OleDbDataAdapter(SQL, conn);
            // This sets the value to be added to the SQL query for the Search String.
            da.SelectCommand.Parameters.AddWithValue("MovieID", FilmID);
            // This generates a DataTable called Results used to store the results of the SQL query.
            DataTable Results = new DataTable();
            // This fills the DataTable with the results.
            da.Fill(Results);
            // Creates a new Member object and fills it with the result from the SQL Query.
            Film F = new Film(Results.Rows[0]);
            return F;

        }


        public static List<Film> SuggestFilm(int userID)
        {
            // This method uses an algorithm to suggest filsm for the user to watch.
            // This if statement says if the Memberrating equals 0 then it builds a new rating and fills the object.
            if (MemberRatings.Count == 0)
            {
                MemberRatings = BuildMemberRating();
            }
            //Reset Common count
            foreach (MemberRating M in MemberRatings)
            {
                M.CommonCount = 0;
            }

            // These Initialize a new list of Films for the recommended films, films which the user has rated and films the user has rated 5.
            List<Film> RecommendedFilms = new List<Film>();
            List<Film> filmsRated = new List<Film>();
            List<Film> filmsRated5 = new List<Film>();
            // This Initializes a new instance of the OleDbConnection object and sets it equal to my method in the DB class.
            OleDbConnection conn = FilmWebsite.DB.OpenConnection();
            // This opens a connection to the database.
            conn.Open();
            // This creates a string which contains the SQL to run.
            string SQL = "Select Movies.MovieID, Movies.Title, Movies.Release, Movies.IMDB, [Movies.Cast], Movies.Director, Movies.Genre, Ratings.Rating FROM Ratings,Movies WHERE MemberID = ? AND Movies.MovieID =  Ratings.MovieID";
            // This initialises a new OleDbDataAdapter which uses the SQL and Connection made previously.
            OleDbDataAdapter da = new OleDbDataAdapter(SQL, conn);
            // This sets the value to be added to the SQL query for the Search String.
            da.SelectCommand.Parameters.AddWithValue("MemberID", userID);
            // This generates a DataTable called Results used to store the results of the SQL query.
            DataTable Results = new DataTable();
            // This fills the DataTable with the results.
            da.Fill(Results);
            // This passes the DataTable one row at a time to the  Film class.
            foreach (DataRow R in Results.Rows)
            {
                // This initialises a new Film object and passes the datarow one line at a time.
                Film F = new Film(R);
                // This adds the Film object to the list which is returned when the method is called.
                filmsRated.Add(F);
                // If the the rating on the films equals 5 then they are added to the Films rated 5 list.
                if (R["Rating"].ToString() == "5")
                {
                    filmsRated5.Add(F);
                }
                conn.Close();
            }


            //Establish which members have most in common with this members favourite Films.
            foreach (Film F in filmsRated5)
            {

                foreach (MemberRating M in MemberRatings)
                {
                    if (M._FilmsRated5.Contains(F))
                    {
                        M.CommonCount++;
                        MemberRatings.ToString().Remove(F.MovieID);
                    }
                }
            }
            // This creates a list of all of the other members films in order of rating.
            MemberRatings = MemberRatings.OrderByDescending(M => M.CommonCount).ToList();

            foreach (MemberRating M in MemberRatings)
            {

                foreach (Film F in M._FilmsRated5)
                {
                    // This makes sure only other users rated films get added to the list.
                    if (M.MemberID != LoggedInMember.MemberID)
                    {
                        if (RecommendedFilms.Count != 5)
                        {
                            if (!filmsRated.Contains(F))
                            {
                                // This adds the films to a list which are suggested.
                                RecommendedFilms.Add(F);
                            }
                        }

                        // This makes sure only 5 films are suggested at a time.
                        if (RecommendedFilms.Count == 5)
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }


            return RecommendedFilms;
        }

        public static List<Film> My5RatedFilms(int MemberID)
        {
            // This method creates a list of films rated 5 by the user.
            // This initialises a new list of films.
            List<Film> _MyFilmsRated5 = new List<Film>();
            // This creates a connection to the database and runs an SQL query to retrieve all of the films rated 5 by the user.
            OleDbConnection conn = FilmWebsite.DB.OpenConnection();
            conn.Open();
            string SQL = "Select Movies.MovieID, Movies.Title, Movies.Release, Movies.IMDB, [Movies.Cast], Movies.Director, Movies.Genre, Ratings.Rating FROM Ratings,Movies WHERE MemberID = ? AND Movies.MovieID =  Ratings.MovieID";
            OleDbDataAdapter da = new OleDbDataAdapter(SQL, conn);
            da.SelectCommand.Parameters.AddWithValue("MemberID", MemberID);
            DataTable Results = new DataTable();
            da.Fill(Results);
            foreach (DataRow R in Results.Rows)
            {
                Film F = new Film(R);
                if (R["Rating"].ToString() == "5")
                {
                    _MyFilmsRated5.Add(F);
                }

            }
            return _MyFilmsRated5;
        }


        public static string GetPosterURL(string Title)
        {
            // This method runs an API query to retrieve the URL for the poster of each film.
            string url = "http://www.omdbapi.com/?t=" + Title.Trim();
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);
                JavaScriptSerializer oJS = new JavaScriptSerializer();
                ImdbEntity obj = new ImdbEntity();
                obj = oJS.Deserialize<ImdbEntity>(json);
                if (obj.Response != null)
                {
                    PosterURL = obj.Poster;

                }


            }
            return PosterURL;

        }


        public static string GetPlot(string Title)
        {
            // This method runs an API query to retrive the plot description.
            string url = "http://www.omdbapi.com/?t=" + Title.Trim();
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);
                JavaScriptSerializer oJS = new JavaScriptSerializer();
                ImdbEntity obj = new ImdbEntity();
                obj = oJS.Deserialize<ImdbEntity>(json);
                if (obj.Response != null)
                {
                    Plot = obj.Plot;
                }
            }
            return Plot;
        }

        public static List<Member> GetFriends(int MemberID)
        {
            // This method retrieves the users friends.
            // This initialises a new list of Members.
            List<Member> MyFriends = new List<Member>();
            // This creates a new connection to the Database and runs an SQL query to fill the list.
            OleDbConnection conn = FilmWebsite.DB.OpenConnection();
            conn.Open();
            string SQL = "Select Friends.FriendID AS MemberID, Members.UserName, Members.FirstName, Members.SecondName, Members.Email, Members.DOB, Members.Pass FROM Friends,Members WHERE Friends.MemberID = ? AND Friends.FriendID = Members.MemberID";
            OleDbDataAdapter da = new OleDbDataAdapter(SQL, conn);
            da.SelectCommand.Parameters.AddWithValue("MemberID", MemberID);
            DataTable Results = new DataTable();
            da.Fill(Results);

            foreach (DataRow R in Results.Rows)
            {
                Member F = new Member(R);
                MyFriends.Add(F);
            }



            return MyFriends;
        }
        public static List<Review> GetReviews(int FilmID)
        {
            // This method retrieves the users reviews.
            // This initialises a new list of Reviews.
            List<Review> ReviewedFilms = new List<Review>();
            // This creates a new connection to the Database and runs an SQL query to fill the list.
            OleDbConnection conn = FilmWebsite.DB.OpenConnection();
            conn.Open();
            string SQL = "Select Ratings.Rating, Ratings.Comment, Ratings.DateOfReview FROM Ratings WHERE Ratings.MovieID = ?";
            OleDbDataAdapter da = new OleDbDataAdapter(SQL, conn);
            da.SelectCommand.Parameters.AddWithValue("MovieID", FilmID);
            DataTable Results = new DataTable();
            da.Fill(Results);

            foreach (DataRow R in Results.Rows)
            {
                Review F = new Review(R);
                ReviewedFilms.Add(F);
            }

            return ReviewedFilms;
        }



        public static string getMd5Hash(string input)
        {
            // Create a new instance of the MD5 object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            int i = 0;
            for (i = 0; i <= data.Length - 1; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();

        }


    }
}
