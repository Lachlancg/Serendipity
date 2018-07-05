<%@ Page Title="" Language="C#" MasterPageFile="~/FilmMasterMember.master" AutoEventWireup="true" CodeFile="MemberFriends.aspx.cs" Inherits="MemberFriends" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="Movie-Info" class="">
        <div class="container">
            <div class="row">
                <div class="">
                     <hr class="line yellow">

                    <h1>
                        <asp:Label ID="Searchfilmstorate" runat="server" Text="Search friends" Style="color: #FFFFFF; font-size: large"></asp:Label>
                    </h1>
                    <asp:TextBox ID="Text1" runat="server" Width="649px"></asp:TextBox>
                    <br />
                    <br />
                </div>
                <div class="">
                   
                    <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1">
                        <ItemTemplate>
                            &nbsp;<h4>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "FriendPage.aspx?MemberID=" + Eval("MemberID") %>' Text='<%# FormatLink(Eval("FirstName").ToString(), Eval("SecondName").ToString()) %>' />
                            
                            </h4>
                            <br />
                            
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SearchResultsFriends" TypeName="FilmWebsite.Repository">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="Text1" Name="SearchString" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>

                </div>
            </div>
        </div>
    </section>
</asp:Content>

