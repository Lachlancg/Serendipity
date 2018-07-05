<%@ Page Title="" Language="C#" MasterPageFile="~/FilmMasterMember.master" AutoEventWireup="true" CodeFile="MemberProfile.aspx.cs" Inherits="MemberProfile" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <section id="main-info" class="">
        <div class="container">
            <div class="row">
                <hr class="line purple">
                <div class="col-sm-4">
                    <asp:Image ID="Image1" runat="server" Height="150px" Width="150px" />
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="fileUpload" />
                    <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Change Profile Picture" CssClass="fileUpload" />
                </div>
                <div class="col-sm-4">
                    <asp:Label ID="Name" runat="server" CssClass="h1" Text="Label" Width="144px"></asp:Label>
                    
                </div>
                <div>
                </div>
            </div>
        </div>
    </section>

    <section id="Favourite Films" class=" ">
        <div class="container">
            <div class="row">
                <hr class="line yellow">
                <div class="col-sm-8 col-sm-offset-2 text-center margin-30 ">
                    <asp:Label ID="Label1" runat="server" CssClass="h2" Text="My favourite Films" Width="400px"></asp:Label>
                    <asp:DataList ID="TopMemberFilms" runat="server" DataSourceID="ObjectDataSource1">
                        <ItemTemplate>
                            <br />
                            <asp:Image ID="Image2" runat="server" />
                            <asp:HyperLink ID="Hyperlink1" runat="server" CssClass="h4" NavigateUrl='<%# "Movie.aspx?FilmID=" + Eval("MovieID") %>' Text='<%# Eval("Title") %>' />
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="My5RatedFilms" TypeName="FilmWebsite.Repository">
                        <SelectParameters>
                            <asp:SessionParameter Name="MemberID" SessionField="thisUserID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>

        </div>
    </section>

    <section id="Following" class=" ">
        <div class="container">
            <div class="row">
                <hr class="line blue">
                <div class="col-sm-8 col-sm-offset-2 text-center margin-30 ">
                    <asp:Label ID="Label2" runat="server" CssClass="h2" Text="Following" Width="400px"></asp:Label>
                    <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource2">
                        <ItemTemplate>
                            <br />
                            <h4>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "FriendPage.aspx?MemberID=" + Eval("MemberID") %>' Text='<%# FormatLink(Eval("FirstName").ToString(), Eval("SecondName").ToString()) %>' />

                            </h4>

                        </ItemTemplate>
                    </asp:DataList>
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetFriends" TypeName="FilmWebsite.Repository">
                        <SelectParameters>
                            <asp:SessionParameter Name="MemberID" SessionField="thisUserID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>

        </div>
    </section>
</asp:Content>


