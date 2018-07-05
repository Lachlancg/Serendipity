<%@ Page Title="" Language="C#" MasterPageFile="~/FilmMasterMember.master" AutoEventWireup="true" CodeFile="Members.aspx.cs" Inherits="Members" %>

<%-- Add content controls here --%>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <section id="Movie-Info" class="">
        <div class="container">
            <div class="row">
                <div class="">
                    <br />
                </div>
                <div class="panel panel-default">
                    <asp:Label ID="Label1" runat="server" Text="Suggested films" CssClass="panel-heading"></asp:Label>

                    <asp:Panel ID="Panel1" runat="server" CssClass="panel">
                        <asp:DataList ID="DataList2" runat="server" DataSourceID="ObjectDataSource2" CssClass="list-group">
                            <ItemTemplate>
                                <br />
                                <%--<asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ImageURL") %>' Height="30" Width="15" />--%>
                                <asp:HyperLink ID="Hyperlink1" runat="server" NavigateUrl='<%# "Movie.aspx?FilmID=" + Eval("MovieID") %>' Text='<%# Eval("Title") %>' CssClass="list-group-item" />
                            </ItemTemplate>
                        </asp:DataList>
                    </asp:Panel>
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="SuggestFilm" TypeName="FilmWebsite.Repository">
                        <SelectParameters>
                            <asp:SessionParameter Name="userID" SessionField="thisUserID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>

                </div>
                <div class="">
                    <hr class="line yellow">

                    <h1>
                        <asp:Label ID="Searchfilmstorate" runat="server" Text="Search films to rate" Style="color: #FFFFFF; font-size: large"></asp:Label>
                    </h1>
                </div>
                <div class="">
                    <asp:TextBox ID="Text1" runat="server" Width="649px" CssClass="form-control"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" CssClass="btn btn-default" />
                </div>
                <div style="width: 90%; overflow: auto">
                    <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" AllowPaging="True" AutoGenerateColumns="False" BorderStyle="None" CellPadding="20" GridLines="None" CellSpacing="2" CssClass="list-group" PageSize="20" ControlStyle-CssClass="list-group" AutoGenerateEditButton="False" Visible="True" Style="width: 100%; overflow: auto"
                        HorizontalAlign="Center">
                        <PagerSettings FirstPageText="First Page" LastPageText="Last Page" Mode="NextPreviousFirstLast" Position="Bottom" />
                        <PagerStyle ForeColor="White" CssClass="pager" />
                        <Columns>
                            <asp:HyperLinkField DataNavigateUrlFields="MovieID" DataNavigateUrlFormatString="Movie.aspx?FilmID={0}" DataTextField="Title" ControlStyle-CssClass="list-group-item" />

                        </Columns>

                    </asp:GridView>

                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SearchResults" TypeName="FilmWebsite.Repository">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="Text1" Name="SearchString" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
        </div>

    </section>

</asp:Content>

