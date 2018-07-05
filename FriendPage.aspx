<%@ Page Title="" Language="C#" MasterPageFile="~/FilmMasterMember.master" AutoEventWireup="true" CodeFile="FriendPage.aspx.cs" Inherits="FriendPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="Movie-Info" class="">
        <div class="container">
            <div class="row">
                <hr class="line purple">
                <div class="col-sm-4">
                    <asp:Image ID="Image1" runat="server" Height="150px" Width="150px" />
                </div>
                <div class="col-sm-4">
                    <asp:Label ID="Name" runat="server" CssClass="h1" Text="Label" Width="144px"></asp:Label>
                </div>
                <div>
                    <asp:Button ID="Button1" runat="server" Text="Follow" OnClick="Button1_Click" CssClass="btn" />
                    <asp:Button ID="Button2" runat="server" Text="Unfollow" OnClick="Button2_Click" Visible="False" CssClass="btn" />

                </div>
            </div>
        </div>
    </section>

    <section id="Favourite Films" class=" ">
        <div class="container">
            <div class="row">
                <hr class="line yellow">
                <div class="col-sm-8 col-sm-offset-2 text-center margin-30 ">
                    <asp:Label ID="Label1" runat="server" CssClass="h2" Text="Favourite Films" Width="400px"></asp:Label>
                    <asp:DataList ID="TopMemberFilms" runat="server" DataSourceID="ObjectDataSource1">
                        <ItemTemplate>
                            <asp:HyperLink ID="Hyperlink1" runat="server" NavigateUrl='<%# "Movie.aspx?FilmID=" + Eval("MovieID") %>' Text='<%# Eval("Title") %>' />
                            
                        </ItemTemplate>
                    </asp:DataList>

                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="My5RatedFilms" TypeName="FilmWebsite.Repository">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="" Name="MemberID" SessionField="thisFriendID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>

        </div>
    </section>
</asp:Content>

