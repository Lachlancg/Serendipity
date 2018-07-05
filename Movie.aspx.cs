using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FilmWebsite;

public partial class Movie : System.Web.UI.Page
{
    // This creates a film object to store the film to display.
    public Film FilmToDisplay;
    // This creates IMDB onject to store all of the IMDB variables.
    public ImdbEntity Obj;

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            // This attempts to fill all of the sections of the page with the information from the Film object.
            int FilmID = int.Parse(Request.QueryString["FilmID"]);
            FilmToDisplay = Repository.SearchFilm(FilmID);
            FilmTitle.Text = FilmToDisplay.Title;
            Genre.Text = FilmToDisplay.Genre;
            Release.Text = FilmToDisplay.Release.ToString();
            Director.Text = FilmToDisplay.Director;
            Cast.Text = FilmToDisplay.Cast;
            Image1.ImageUrl = FilmWebsite.Repository.GetPosterURL(FilmToDisplay.Title);
            Description.Text = FilmWebsite.Repository.GetPlot(FilmToDisplay.Title);

        }
        catch (Exception)
        {
            // If it doesnt work then it takes you to the main page.
            Response.Redirect("Members.aspx");
        }
        
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        // Checks to see if the film has already been reviewed by the user.
        // If not it adds the review to the database.
        bool alreadyReviewed;
        Member CurrentMember = new Member(Convert.ToString(Session["thisUserID"]));
        Review NewReview = new Review(CurrentMember, FilmToDisplay, DropDownList1.SelectedValue, TextBox1.Text);
        alreadyReviewed = NewReview.save();
        if (alreadyReviewed == false)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Already reviewed this film" + "');", true);
        }
        Response.Redirect(Request.RawUrl);

        
    }
}