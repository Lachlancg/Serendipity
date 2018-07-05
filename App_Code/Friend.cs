using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using FilmWebsite;

/// <summary>
/// Summary description for Friend
/// </summary>
public class Friend
{
    // This class builds a Member object, which creates an object with all of the data of each Friend when run.
    // The following instantiates the variables used within the object.
    public Member MyUser;

    public string FriendUser;

    private DateTime _dateAdded;

    public DateTime DateAdded
    {
        get { return _dateAdded; }
        set { _dateAdded = value; }
    }

    private int _memberID;

    public int MemberID
    {
        get { return _memberID; }
        set { _memberID = value; }
    }

    private int _freindID;

    public int FriendID
    {
        get { return _freindID; }
        set { _freindID = value; }
    }
    private string _friendName;

    public string FriendName
    {
        get { return _friendName; }
        set { _friendName = value; }
    }
    private bool _isFriend;
    public bool IsFriend
    {
        get { return IsFriend; }
        set { IsFriend = value; }
    }

    public Friend(DataRow DR)
    {
        // Sets the variables equal to the variables in the DataRow.
        _dateAdded = DateTime.Parse(DR["CreateDate"].ToString());
        _memberID = int.Parse(DR["MemberID"].ToString());
        _freindID = int.Parse(DR["FriendID"].ToString());
        _friendName = DR["FirstName"].ToString();
    }

    public Friend(Member M,string F)
    {
        // Sets the variables equal to the variables passed to the method.
        MyUser = M;
        FriendUser = F;
        _dateAdded = DateTime.Today;
    }
    public bool save()
    {
        // This method saves the freind object into the database.
        // This creates a connection with the database and then runs an SQL query to fill the table.
        OleDbConnection conn = FilmWebsite.DB.OpenConnection();
        conn.Open();


        string isql = "INSERT INTO Friends (MemberID, FriendID, CreateDate) VALUES (?,?,?)";
        OleDbCommand Cmd = new OleDbCommand(isql, conn);
        Cmd.Parameters.AddWithValue("MemberID", MyUser.MemberID);
        Cmd.Parameters.AddWithValue("FriendID", FriendUser);
        Cmd.Parameters.AddWithValue("CreateDate", _dateAdded);
        try
        {
            Cmd.ExecuteNonQuery();

            Cmd.CommandText = "SELECT @@Identity";
            MyUser.MemberID = (int)Cmd.ExecuteScalar(); conn.Close();
            return false;
        }
        catch (Exception)
        {
            conn.Close();
            return true;

        }

    }

    public bool Delete()
    {
        // This code can be run to delete friends from the database.
        OleDbConnection conn = FilmWebsite.DB.OpenConnection();
        conn.Open();


        string dsql = "DELETE FROM Friends WHERE MemberID = ? AND FriendID = ?";
        OleDbCommand DCmd = new OleDbCommand(dsql, conn);
        DCmd.Parameters.AddWithValue("MemberID", MyUser.MemberID);
        DCmd.Parameters.AddWithValue("FriendID", FriendUser);

        try
        {
            DCmd.ExecuteNonQuery();          
            return false;
        }
        catch (Exception)
        {
            conn.Close();
            return true;

        }
    }
}