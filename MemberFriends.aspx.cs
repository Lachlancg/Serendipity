using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MemberFriends : System.Web.UI.Page
{
    // This creates a new string for the search string.
    private string _inputSearch;
    public string InputSearch
    {
        get { return _inputSearch; }
        set { _inputSearch = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string FormatLink(string FirstName, string SecondName)
    {
        // This method formats the URL so it includes the first and second name.
        return FirstName + " " + SecondName;
    }
}