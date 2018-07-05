<%@ Page Title="" Language="C#" MasterPageFile="~/FilmMasterMember.master" AutoEventWireup="true" CodeFile="Rate5.aspx.cs" Inherits="Rate5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="">
          <p>
              Please rate 5 films, once done press continue to get suggestion of what to watch.
          </p>
                    <hr class="line yellow">

                    <h1>
                        <asp:Label ID="Searchfilmstorate" runat="server" Text="Search films to rate" Style="color: #FFFFFF; font-size: large"></asp:Label>
                    </h1>
                </div>
               
                <div class="">
                    <asp:TextBox ID="Text1" runat="server" Width="649px" CssClass="form-control"></asp:TextBox>
                    <asp:Button ID="Button3" runat="server" Text="Search" OnClick="Button1_Click" CssClass="btn btn-default" />
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
                    <asp:Button ID="Button2" runat="server" Text="Continue" OnClick="Button2_Click" CssClass="btn btn-default" />

</asp:Content>

