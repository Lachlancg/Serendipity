using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace FilmWebsite
{
    public class Member
    {
        // This class builds a Member object, which creates an object with all of the data of each Member when run.
        // The following instantiates the variables used within the object.
        private int _MemberID;

        public int MemberID
        {
            get { return _MemberID; }
            set { _MemberID = value; }
        }
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }


        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _secondName;

        public string SecondName
        {
            get { return _secondName; }
            set { _secondName = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private DateTime _dateOfBirth;

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _password;



        public Member()
        {
            _MemberID = -1;
        }

        public Member(string ID)
        {
            // Sets the variables equal to the results from the database when it runs an SQL query using the MemberID.
            OleDbConnection conn = FilmWebsite.DB.OpenConnection();
            conn.Open();
            string SQL = "Select * FROM Members WHERE MemberID LIKE ?";
            OleDbDataAdapter da = new OleDbDataAdapter(SQL, conn);
            da.SelectCommand.Parameters.AddWithValue("MemberID", ID);
            DataTable Results = new DataTable();
            da.Fill(Results);
            SetMember(Results.Rows[0]);
            conn.Close();
        }


        public Member(DataRow DR)
        {
            // This creates a Member object when the method is passed a datarow.
            SetMember(DR);

        }

        private void SetMember(DataRow DR)
        {
            // Sets the variables equal to the variables in the DataRow.
            _MemberID = int.Parse(DR["MemberID"].ToString());
            _userName = DR["UserName"].ToString();
            _firstName = DR["FirstName"].ToString();
            _secondName = DR["SecondName"].ToString();
            _email = DR["Email"].ToString();
            _dateOfBirth = DateTime.Parse(DR["DOB"].ToString());
            _password = DR["Pass"].ToString();
        }

        public void save()
        {
            // This method saves the Member object into the database.
            // This creates a connection with the database and then runs an SQL query to fill the table.
            OleDbConnection conn = FilmWebsite.DB.OpenConnection();
            conn.Open();
            if (_MemberID == -1)
            {

                string isql = "INSERT INTO Members (FirstName, SecondName, Email, DOB, Pass) VALUES (?,?,?,?,?)";
                OleDbCommand Cmd = new OleDbCommand(isql, conn);
                Cmd.Parameters.AddWithValue("FirstName", _firstName);
                Cmd.Parameters.AddWithValue("SecondName", _secondName);
                Cmd.Parameters.AddWithValue("Email", _email);
                Cmd.Parameters.AddWithValue("DOB", _dateOfBirth);
                Cmd.Parameters.AddWithValue("Pass", _password);
                Cmd.ExecuteNonQuery();

                Cmd.CommandText = "SELECT @@Identity";
                _MemberID = (int)Cmd.ExecuteScalar();
            }

            else
            {
                string isql = "INSERT INTO Members (FirstName, SecondName, Email, DOB, Pass) VALUES (?,?,?,?,?)";
                OleDbCommand Cmd = new OleDbCommand(isql, conn);
                Cmd.Parameters.AddWithValue("FirstName", _firstName);
                Cmd.Parameters.AddWithValue("SecondName", _secondName);
                Cmd.Parameters.AddWithValue("Email", _email);
                Cmd.Parameters.AddWithValue("DateOfBirth", _dateOfBirth);
                Cmd.Parameters.AddWithValue("Password", _password);
                Cmd.ExecuteNonQuery();

            }
            conn.Close();
        }
     }
}
