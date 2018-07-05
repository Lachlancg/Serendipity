<%@ Page Title="" Language="C#" MasterPageFile="~/FilmMaster.master" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="SignUp" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">


    <section id="Login" class="col-xs-6">
        <div class="container">
            <div class="row">
                <div class="col-sm-8 col-sm-offset-2 text-center margin-30 wow fadeIn" data-wow-delay="0.6s">
                    <h1>Login</h1>
                </div>
<%--                <div class="col-sm-8 col-md-offset-2">--%>
                <div class="col-sm-8 col-md-offset-2">
                    <asp:TextBox ID="Email" CssClass="form-control" runat="server" TextMode="Email" placeholder="Email" AutoCompleteType="Email" Type="Email"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" ControlToValidate="Email" Visible="False"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="Password" CssClass="form-control" runat="server" TextMode="Password" placeholder="Password" Type="Password"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="^(?!\\s*$).+" ControlToValidate="Password" Visible="False"></asp:RegularExpressionValidator>
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="Button2_Click" Text="Sign In" />
                    <a href="SignUp.aspx" class="lead wow fadeIn">Create an account </a>
                </div>

            </div>

        </div>
    </section>

</asp:Content>

