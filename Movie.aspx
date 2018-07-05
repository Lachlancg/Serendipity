<%@ Page Title="" Language="C#" MasterPageFile="~/FilmMasterMember.master" AutoEventWireup="true" CodeFile="Movie.aspx.cs" Inherits="Movie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <section id="Movie-Info" class="">
        <div class="container">
            <div class="row">
                <div class="">
                    <hr class="line purple">
                    <asp:Image ID="Image1" runat="server" Height="250px" Width="150px" />
                    <asp:Label ID="FilmTitle" runat="server" Text="Title" Style="text-align: right; color: #FFFFFF;" CssClass="h2"></asp:Label>

                </div>
                <div>
                    <asp:Label ID="Label2" runat="server" Text="Genre: " Style="color: #FFFFFF" CssClass="h4"></asp:Label>
                    <asp:Label ID="Genre" runat="server" Text="Genre" Style="color: #FFFFFF" CssClass="h4"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label3" runat="server" Text="Release date: " Style="color: #FFFFFF" CssClass="h4"></asp:Label>
                    <asp:Label ID="Release" runat="server" Text="Release" Style="color: #FFFFFF" CssClass="h4"></asp:Label>
                </div>
                <div class="">
                    <asp:Label ID="Label4" runat="server" Text="Director: " Style="color: #FFFFFF" CssClass="h4"></asp:Label>
                    <asp:Label ID="Director" runat="server" Text="Director" Style="color: #FFFFFF" CssClass="h4"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label5" runat="server" Text="Cast: " Style="color: #FFFFFF" CssClass="h4"></asp:Label>
                    <asp:Label ID="Cast" runat="server" Text="Cast" Style="color: #FFFFFF" CssClass="h4"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Description: " Style="color: #FFFFFF" CssClass="h4"></asp:Label>
                    <asp:Label ID="Description" runat="server" Text="Description" Style="color: #FFFFFF" CssClass="h4"></asp:Label>
                </div>

                <div class="">
                    <hr class="line blue">
                    <div>
                        <h3 class="h4">Reviews</h3>
                        <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1">
                            <ItemTemplate>
                                <h5>
                                    <asp:Label ID="RatingLabel" runat="server" Text='<%# Eval("Rating") %>' />
                                </h5>
                                <h5>
                                    <asp:Label ID="CommentLabel" runat="server" Text='<%# Eval("Comment") %>' />
                                </h5>
                                <h5>
                                    <asp:Label ID="DateOfReviewLabel" runat="server" Text='<%# Eval("DateOfReview") %>' />
                                </h5>
                                <br />
                                <br />
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetReviews" TypeName="FilmWebsite.Repository">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="FilmID" QueryStringField="FilmID" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                    <hr class="line green">

                    <div class="">
                        <div>
                            <h3 class="h4">Leave a review</h3>
                        </div>
                        <div>
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="btn btn-default dropdown-toggle">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div>
                            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Button ID="Review" runat="server" Text="Review" OnClick="Button1_Click" CssClass="btn btn-default" />

                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>






</asp:Content>

